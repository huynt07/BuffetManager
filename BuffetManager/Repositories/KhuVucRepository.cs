using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class KhuVucRepository
    {
        // Đếm số khu vực đang có trong database
        public int DemKhuVuc()
        {
            // Tự giải phóng DataContext sau khi sử dụng
            using (var db = DbFactory.Create())
            {
                // Thực hiện truy vấn LINQ xuống SQL Server
                return db.GetTable<KHUVUC>().Count();
            }
        }

        // Lấy danh sách khu vực, sắp xếp theo tên
        public List<KHUVUC> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<KHUVUC>()
                         .OrderBy(kv => kv.TenKV)
                         .ToList();
            }
        }

        // Thêm khu vực mới vào database
        public void Them(string tenKV)
        {
            using (var db = DbFactory.Create())
            {
                // Kiểm tra tên khu vực đã tồn tại
                bool trungTen = db.GetTable<KHUVUC>()
                                  .Any(kv => kv.TenKV == tenKV);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên khu vực đã tồn tại.");
                }

                // MaKV tự tăng nên không cần gán
                var khuVuc = new KHUVUC
                {
                    TenKV = tenKV
                };

                // Đánh dấu thêm và lưu xuống database
                db.GetTable<KHUVUC>().InsertOnSubmit(khuVuc);
                db.SubmitChanges();
            }
        }

        // Cập nhật tên của khu vực được chọn
        public void Sua(int maKV, string tenKV)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm khu vực theo mã
                var khuVuc = db.GetTable<KHUVUC>()
                              .SingleOrDefault(kv => kv.MaKV == maKV);

                if (khuVuc == null)
                {
                    throw new InvalidOperationException(
                        "Khu vực không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra trùng tên với khu vực khác
                bool trungTen = db.GetTable<KHUVUC>()
                    .Any(kv => kv.TenKV == tenKV && kv.MaKV != maKV);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên khu vực đã tồn tại.");
                }

                // Cập nhật và lưu xuống database
                khuVuc.TenKV = tenKV;
                db.SubmitChanges();
            }
        }

        // Chỉ xóa khu vực chưa có bàn
        public void Xoa(int maKV)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm khu vực cần xóa
                var khuVuc = db.GetTable<KHUVUC>()
                              .SingleOrDefault(kv => kv.MaKV == maKV);

                if (khuVuc == null)
                {
                    throw new InvalidOperationException(
                        "Khu vực không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra có bàn nào thuộc khu vực này không
                bool daCoBan = db.GetTable<BAN>()
                                .Any(b => b.MaKV == maKV);

                if (daCoBan)
                {
                    throw new InvalidOperationException(
                        "Khu vực đã có bàn, không thể xóa.");
                }

                // Đánh dấu xóa và lưu thay đổi
                db.GetTable<KHUVUC>().DeleteOnSubmit(khuVuc);
                db.SubmitChanges();
            }
        }
    }
}
