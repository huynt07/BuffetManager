using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class GoiBuffetRepository
    {
        // Lấy danh sách gói, sắp xếp theo giá rồi tên
        public List<GOIBUFFET> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<GOIBUFFET>()
                         .OrderBy(goi => goi.GiaNguoiLon)
                         .ThenBy(goi => goi.TenGoi)
                         .ToList();
            }
        }

        // Thêm gói buffet mới vào database
        public void Them(
            string tenGoi,
            decimal giaNguoiLon,
            decimal donGiaPhatMoiKg,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Không cho phép trùng tên gói
                bool trungTen = db.GetTable<GOIBUFFET>()
                                  .Any(goi => goi.TenGoi == tenGoi);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên gói buffet đã tồn tại.");
                }

                // MaGoi được SQL Server tự tăng
                var goiBuffet = new GOIBUFFET
                {
                    TenGoi = tenGoi,
                    GiaNguoiLon = giaNguoiLon,
                    DonGiaPhatMoiKg = donGiaPhatMoiKg,
                    DangBan = dangBan
                };

                // Đánh dấu thêm và lưu dữ liệu
                db.GetTable<GOIBUFFET>().InsertOnSubmit(goiBuffet);
                db.SubmitChanges();
            }
        }

        // Cập nhật thông tin gói buffet
        public void Sua(
            int maGoi,
            string tenGoi,
            decimal giaNguoiLon,
            decimal donGiaPhatMoiKg,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm gói cần sửa
                var goi = db.GetTable<GOIBUFFET>()
                            .SingleOrDefault(g => g.MaGoi == maGoi);

                if (goi == null)
                {
                    throw new InvalidOperationException(
                        "Gói buffet không tồn tại hoặc đã bị xóa.");
                }

                // Không trùng tên với gói khác
                bool trungTen = db.GetTable<GOIBUFFET>()
                    .Any(g => g.TenGoi == tenGoi && g.MaGoi != maGoi);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên gói buffet đã tồn tại.");
                }

                // Cập nhật các thông tin được phép sửa
                goi.TenGoi = tenGoi;
                goi.GiaNguoiLon = giaNguoiLon;
                goi.DonGiaPhatMoiKg = donGiaPhatMoiKg;
                goi.DangBan = dangBan;

                db.SubmitChanges();
            }
        }

        // Chỉ xóa gói chưa có dữ liệu liên quan
        public void Xoa(int maGoi)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm gói cần xóa
                var goi = db.GetTable<GOIBUFFET>()
                            .SingleOrDefault(g => g.MaGoi == maGoi);

                if (goi == null)
                {
                    throw new InvalidOperationException(
                        "Gói buffet không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra lịch sử sử dụng, kể cả lượt đã kết thúc
                bool daSuDung = db.GetTable<LUOTPHUCVU>()
                    .Any(luot => luot.MaGoi == maGoi);

                if (daSuDung)
                {
                    throw new InvalidOperationException(
                        "Gói buffet đã có lịch sử sử dụng, không thể xóa.");
                }

                // Kiểm tra danh sách món thuộc gói
                bool daCoMon = db.GetTable<GOIBUFFET_MON>()
                    .Any(ct => ct.MaGoi == maGoi);

                if (daCoMon)
                {
                    throw new InvalidOperationException(
                        "Gói buffet đang có món liên kết, không thể xóa.");
                }

                // Xóa gói và lưu thay đổi
                db.GetTable<GOIBUFFET>().DeleteOnSubmit(goi);
                db.SubmitChanges();
            }
        }
    }
}
