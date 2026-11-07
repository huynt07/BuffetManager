using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuffetManager.Repositories
{
    public class ComboMonRepository
    {
        // Lấy danh sách món của combo được chọn
        public List<ComboMonDTO> LayDanhSach(int maCombo)
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from ct in db.GetTable<COMBO_MON>()
                    join mon in db.GetTable<MONAN>()
                        on ct.MaMon equals mon.MaMon
                    where ct.MaCombo == maCombo
                    orderby mon.TenMon
                    select new ComboMonDTO
                    {
                        MaCombo = ct.MaCombo,
                        MaMon = ct.MaMon,
                        TenMon = mon.TenMon,
                        DonVi = mon.DonVi,
                        SoLuong = ct.SoLuong,
                        DangBan = mon.DangBan
                    };

                // Đọc dữ liệu trước khi đóng DataContext
                return query.ToList();
            }
        }

        // Thêm một món với số lượng cố định vào combo
        public void Them(int maCombo, int maMon, int soLuong)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Kiểm tra combo tồn tại
                if (!db.GetTable<COMBO>()
                       .Any(cb => cb.MaCombo == maCombo))
                {
                    throw new InvalidOperationException(
                        "Combo không tồn tại.");
                }

                // Chỉ thêm món còn đang bán
                if (!db.GetTable<MONAN>()
                       .Any(m => m.MaMon == maMon && m.DangBan))
                {
                    throw new InvalidOperationException(
                        "Món không tồn tại hoặc đã ngừng bán.");
                }

                // Không thêm trùng món trong cùng combo
                if (db.GetTable<COMBO_MON>()
                      .Any(ct => ct.MaCombo == maCombo && ct.MaMon == maMon))
                {
                    throw new InvalidOperationException(
                        "Món đã có trong combo. Hãy dùng Sửa số lượng.");
                }

                // Kiểm tra có khách đang sử dụng combo này không
                var luotDangDung =
                    from lc in db.GetTable<LUACHONCOMBO>()
                    join luot in db.GetTable<LUOTPHUCVU>()
                        on lc.MaLuot equals luot.MaLuot
                    where lc.MaCombo == maCombo
                       && luot.TrangThai == "DANG_PHUC_VU"
                    select lc.MaChonCombo;

                if (luotDangDung.Any())
                {
                    throw new InvalidOperationException(
                        "Có khách đang sử dụng combo, chưa thể thay đổi món.");
                }

                // Tạo liên kết món với combo
                var chiTiet = new COMBO_MON
                {
                    MaCombo = maCombo,
                    MaMon = maMon,
                    SoLuong = soLuong
                };

                db.GetTable<COMBO_MON>().InsertOnSubmit(chiTiet);
                db.SubmitChanges();

                scope.Complete();
            }
        }

        // Cập nhật số lượng của một món trong combo
        public void Sua(int maCombo, int maMon, int soLuong)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Tìm đúng liên kết combo và món
                var chiTiet = db.GetTable<COMBO_MON>()
                    .SingleOrDefault(ct =>
                        ct.MaCombo == maCombo && ct.MaMon == maMon);

                if (chiTiet == null)
                {
                    throw new InvalidOperationException(
                        "Món không còn thuộc combo này.");
                }

                // Không đổi số lượng khi có khách đang dùng combo
                var luotDangDung =
                    from lc in db.GetTable<LUACHONCOMBO>()
                    join luot in db.GetTable<LUOTPHUCVU>()
                        on lc.MaLuot equals luot.MaLuot
                    where lc.MaCombo == maCombo
                       && luot.TrangThai == "DANG_PHUC_VU"
                    select lc.MaChonCombo;

                if (luotDangDung.Any())
                {
                    throw new InvalidOperationException(
                        "Có khách đang sử dụng combo, chưa thể sửa số lượng món.");
                }

                // Chỉ sửa số lượng, giữ nguyên combo và món
                chiTiet.SoLuong = soLuong;

                db.SubmitChanges();
                scope.Complete();
            }
        }

        // Gỡ một món khỏi combo
        public void Xoa(int maCombo, int maMon)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Tìm đúng liên kết cần xóa
                var chiTiet = db.GetTable<COMBO_MON>()
                    .SingleOrDefault(ct =>
                        ct.MaCombo == maCombo && ct.MaMon == maMon);

                if (chiTiet == null)
                {
                    throw new InvalidOperationException(
                        "Món không còn thuộc combo này.");
                }

                // Không đổi thành phần khi có khách đang dùng combo
                var luotDangDung =
                    from lc in db.GetTable<LUACHONCOMBO>()
                    join luot in db.GetTable<LUOTPHUCVU>()
                        on lc.MaLuot equals luot.MaLuot
                    where lc.MaCombo == maCombo
                       && luot.TrangThai == "DANG_PHUC_VU"
                    select lc.MaChonCombo;

                if (luotDangDung.Any())
                {
                    throw new InvalidOperationException(
                        "Có khách đang sử dụng combo, chưa thể gỡ món.");
                }

                // Chỉ xóa liên kết, giữ nguyên dữ liệu trong MONAN
                db.GetTable<COMBO_MON>().DeleteOnSubmit(chiTiet);
                db.SubmitChanges();

                scope.Complete();
            }
        }
    }
}
