using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class MonAnRepository
    {
        // Lấy danh sách món và tên danh mục tương ứng
        public List<MonAnDTO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from mon in db.GetTable<MONAN>()
                    join dm in db.GetTable<DANHMUCMON>()
                        on mon.MaDM equals dm.MaDM
                    orderby dm.TenDM, mon.TenMon
                    select new MonAnDTO
                    {
                        MaMon = mon.MaMon,
                        MaDM = mon.MaDM,
                        TenMon = mon.TenMon,
                        TenDM = dm.TenDM,
                        DonVi = mon.DonVi,
                        GiaLe = mon.GiaLe,
                        DangBan = mon.DangBan
                    };

                // Thực thi truy vấn trước khi đóng DataContext
                return query.ToList();
            }
        }

        // Thêm món ăn mới vào database
        public void Them(
            string tenMon,
            int maDM,
            string donVi,
            decimal giaLe,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Kiểm tra danh mục được chọn có tồn tại
                if (!db.GetTable<DANHMUCMON>()
                       .Any(dm => dm.MaDM == maDM))
                {
                    throw new InvalidOperationException(
                        "Danh mục không tồn tại.");
                }

                // Không cho thêm món trùng tên trong cùng danh mục
                bool trungTen = db.GetTable<MONAN>()
                    .Any(mon => mon.MaDM == maDM && mon.TenMon == tenMon);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên món đã tồn tại trong danh mục này.");
                }

                // MaMon được SQL Server tự tăng
                var monAn = new MONAN
                {
                    TenMon = tenMon,
                    MaDM = maDM,
                    DonVi = donVi,
                    GiaLe = giaLe,
                    DangBan = dangBan
                };

                // Đánh dấu thêm và lưu dữ liệu
                db.GetTable<MONAN>().InsertOnSubmit(monAn);
                db.SubmitChanges();
            }
        }

        // Cập nhật thông tin món ăn
        public void Sua(
            int maMon,
            string tenMon,
            int maDM,
            string donVi,
            decimal giaLe,
            bool dangBan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm món cần sửa
                var mon = db.GetTable<MONAN>()
                            .SingleOrDefault(m => m.MaMon == maMon);

                if (mon == null)
                {
                    throw new InvalidOperationException(
                        "Món không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra danh mục được chọn
                var danhMucMoi = db.GetTable<DANHMUCMON>()
                    .SingleOrDefault(dm => dm.MaDM == maDM);

                if (danhMucMoi == null)
                {
                    throw new InvalidOperationException(
                        "Danh mục không tồn tại.");
                }

                // Không trùng tên với món khác trong cùng danh mục
                bool trungTen = db.GetTable<MONAN>()
                    .Any(m => m.MaDM == maDM
                           && m.TenMon == tenMon
                           && m.MaMon != maMon);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên món đã tồn tại trong danh mục này.");
                }

                // Kiểm tra khi chuyển món sang danh mục khác
                if (mon.MaDM != maDM)
                {
                    var danhMucCu = db.GetTable<DANHMUCMON>()
                        .Single(dm => dm.MaDM == mon.MaDM);

                    // Giữ nguyên bộ phận xử lý của món
                    if (danhMucCu.BoPhan != danhMucMoi.BoPhan)
                    {
                        throw new InvalidOperationException(
                            "Chỉ được chuyển món sang danh mục cùng bộ phận.");
                    }
                }

                // Cập nhật thông tin
                mon.TenMon = tenMon;
                mon.MaDM = maDM;
                mon.DonVi = donVi;
                mon.GiaLe = giaLe;
                mon.DangBan = dangBan;

                db.SubmitChanges();
            }
        }

        // Chỉ xóa món chưa có dữ liệu liên quan
        public void Xoa(int maMon)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm món cần xóa
                var mon = db.GetTable<MONAN>()
                            .SingleOrDefault(m => m.MaMon == maMon);

                if (mon == null)
                {
                    throw new InvalidOperationException(
                        "Món không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra món thuộc gói buffet
                if (db.GetTable<GOIBUFFET_MON>()
                      .Any(ct => ct.MaMon == maMon))
                {
                    throw new InvalidOperationException(
                        "Món đang thuộc gói buffet, không thể xóa.");
                }

                // Kiểm tra món thuộc combo
                if (db.GetTable<COMBO_MON>()
                      .Any(ct => ct.MaMon == maMon))
                {
                    throw new InvalidOperationException(
                        "Món đang thuộc combo, không thể xóa.");
                }

                // Kiểm tra công thức nguyên liệu của món
                if (db.GetTable<DINHLUONG>()
                      .Any(dl => dl.MaMon == maMon))
                {
                    throw new InvalidOperationException(
                        "Món đã có định lượng nguyên liệu, không thể xóa.");
                }

                // Kiểm tra lịch sử gọi món, kể cả dòng đã hủy
                if (db.GetTable<CHITIETGOIMON>()
                      .Any(ct => ct.MaMon == maMon))
                {
                    throw new InvalidOperationException(
                        "Món đã có lịch sử gọi, không thể xóa.");
                }

                // Xóa món và lưu thay đổi
                db.GetTable<MONAN>().DeleteOnSubmit(mon);
                db.SubmitChanges();
            }
        }
    }
}
