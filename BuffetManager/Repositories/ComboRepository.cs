using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class ComboRepository
    {
        // Lấy danh sách combo, sắp xếp theo giá rồi tên
        public List<COMBO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<COMBO>()
                         .OrderBy(cb => cb.GiaCombo)
                         .ThenBy(cb => cb.TenCombo)
                         .ToList();
            }
        }

        // Thêm combo mới vào database
        public void Them(
            string tenCombo,
            int soNguoiGoiY,
            decimal giaCombo,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Không cho phép trùng tên combo
                bool trungTen = db.GetTable<COMBO>()
                                  .Any(cb => cb.TenCombo == tenCombo);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên combo đã tồn tại.");
                }

                // MaCombo được SQL Server tự tăng
                var combo = new COMBO
                {
                    TenCombo = tenCombo,
                    SoNguoiGoiY = soNguoiGoiY,
                    GiaCombo = giaCombo,
                    DangBan = dangBan
                };

                // Đánh dấu thêm và lưu dữ liệu
                db.GetTable<COMBO>().InsertOnSubmit(combo);
                db.SubmitChanges();
            }
        }

        // Cập nhật thông tin combo
        public void Sua(
            int maCombo,
            string tenCombo,
            int soNguoiGoiY,
            decimal giaCombo,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm combo cần sửa
                var combo = db.GetTable<COMBO>()
                    .SingleOrDefault(cb => cb.MaCombo == maCombo);

                if (combo == null)
                {
                    throw new InvalidOperationException(
                        "Combo không tồn tại hoặc đã bị xóa.");
                }

                // Không trùng tên với combo khác
                bool trungTen = db.GetTable<COMBO>()
                    .Any(cb => cb.TenCombo == tenCombo
                            && cb.MaCombo != maCombo);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên combo đã tồn tại.");
                }

                // Cập nhật thông tin
                combo.TenCombo = tenCombo;
                combo.SoNguoiGoiY = soNguoiGoiY;
                combo.GiaCombo = giaCombo;
                combo.DangBan = dangBan;

                db.SubmitChanges();
            }
        }

        // Chỉ xóa combo chưa có dữ liệu liên quan
        public void Xoa(int maCombo)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm combo cần xóa
                var combo = db.GetTable<COMBO>()
                    .SingleOrDefault(cb => cb.MaCombo == maCombo);

                if (combo == null)
                {
                    throw new InvalidOperationException(
                        "Combo không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra lịch sử khách chọn combo
                bool daSuDung = db.GetTable<LUACHONCOMBO>()
                    .Any(lc => lc.MaCombo == maCombo);

                if (daSuDung)
                {
                    throw new InvalidOperationException(
                        "Combo đã có lịch sử sử dụng, không thể xóa.");
                }

                // Kiểm tra danh sách món thuộc combo
                bool daCoMon = db.GetTable<COMBO_MON>()
                    .Any(ct => ct.MaCombo == maCombo);

                if (daCoMon)
                {
                    throw new InvalidOperationException(
                        "Combo đang có món liên kết, không thể xóa.");
                }

                // Xóa combo và lưu thay đổi
                db.GetTable<COMBO>().DeleteOnSubmit(combo);
                db.SubmitChanges();
            }
        }
    }
}
