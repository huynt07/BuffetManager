using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class BanRepository
    {
        // Lấy danh sách bàn và tên khu vực tương ứng
        public List<BanDTO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from ban in db.GetTable<BAN>()
                    join kv in db.GetTable<KHUVUC>()
                        on ban.MaKV equals kv.MaKV
                    orderby kv.TenKV, ban.TenBan
                    select new BanDTO
                    {
                        MaBan = ban.MaBan,
                        MaKV = ban.MaKV,
                        TenBan = ban.TenBan,
                        TenKV = kv.TenKV,
                        SoCho = ban.SoCho,
                        HoatDong = ban.HoatDong
                    };

                // Đọc dữ liệu trước khi đóng DataContext
                return query.ToList();
            }
        }

        // Thêm bàn mới vào database
        public void Them(
            string tenBan,
            int maKV,
            int soCho,
            bool hoatDong)
        {
            using (var db = DbFactory.Create())
            {
                // Kiểm tra khu vực được chọn có tồn tại
                if (!db.GetTable<KHUVUC>().Any(kv => kv.MaKV == maKV))
                {
                    throw new InvalidOperationException(
                        "Khu vực không tồn tại.");
                }

                // Tên bàn không được trùng trong toàn nhà hàng
                if (db.GetTable<BAN>().Any(b => b.TenBan == tenBan))
                {
                    throw new InvalidOperationException(
                        "Tên bàn đã tồn tại.");
                }

                // Tạo bàn mới; MaBan được SQL Server tự tăng
                var ban = new BAN
                {
                    TenBan = tenBan,
                    MaKV = maKV,
                    SoCho = soCho,
                    HoatDong = hoatDong
                };

                db.GetTable<BAN>().InsertOnSubmit(ban);
                db.SubmitChanges();
            }
        }

        // Cập nhật thông tin bàn
        public void Sua(
            int maBan,
            string tenBan,
            int maKV,
            int soCho,
            bool hoatDong)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm bàn cần sửa
                var ban = db.GetTable<BAN>()
                            .SingleOrDefault(b => b.MaBan == maBan);

                if (ban == null)
                {
                    throw new InvalidOperationException(
                        "Bàn không tồn tại hoặc đã bị xóa.");
                }

                // Bàn đang gắn với lượt phục vụ chưa kết thúc
                bool dangPhucVu = db.GetTable<LUOTBAN>()
                    .Any(lb => lb.MaBan == maBan && lb.DenLuc == null);

                if (dangPhucVu)
                {
                    throw new InvalidOperationException(
                        "Bàn đang phục vụ, không thể sửa thông tin.");
                }

                // Bàn còn lượt đặt chưa đón khách hoặc chưa hủy
                bool dangDuocDat = db.GetTable<DATBAN>()
                    .Any(d => d.MaBan == maBan && d.TrangThai == "CHO");

                if (dangDuocDat)
                {
                    throw new InvalidOperationException(
                        "Bàn còn lượt đặt đang chờ, không thể sửa thông tin.");
                }

                // Kiểm tra khu vực tồn tại
                if (!db.GetTable<KHUVUC>().Any(kv => kv.MaKV == maKV))
                {
                    throw new InvalidOperationException(
                        "Khu vực không tồn tại.");
                }

                // Không trùng tên với bàn khác
                if (db.GetTable<BAN>()
                      .Any(b => b.TenBan == tenBan && b.MaBan != maBan))
                {
                    throw new InvalidOperationException(
                        "Tên bàn đã tồn tại.");
                }

                // Cập nhật các thuộc tính được phép sửa
                ban.TenBan = tenBan;
                ban.MaKV = maKV;
                ban.SoCho = soCho;
                ban.HoatDong = hoatDong;

                db.SubmitChanges();
            }
        }

        // Chỉ xóa bàn chưa có lịch sử phục vụ hoặc đặt bàn
        public void Xoa(int maBan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm bàn cần xóa
                var ban = db.GetTable<BAN>()
                            .SingleOrDefault(b => b.MaBan == maBan);

                if (ban == null)
                {
                    throw new InvalidOperationException(
                        "Bàn không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra mọi lượt phục vụ, kể cả đã kết thúc
                bool coLuotPhucVu = db.GetTable<LUOTBAN>()
                    .Any(lb => lb.MaBan == maBan);

                if (coLuotPhucVu)
                {
                    throw new InvalidOperationException(
                        "Bàn đã có lịch sử phục vụ, không thể xóa.");
                }

                // Kiểm tra mọi lượt đặt, kể cả đã đến hoặc đã hủy
                bool coDatBan = db.GetTable<DATBAN>()
                    .Any(d => d.MaBan == maBan);

                if (coDatBan)
                {
                    throw new InvalidOperationException(
                        "Bàn đã có lịch sử đặt bàn, không thể xóa.");
                }

                // Xóa bàn và lưu thay đổi
                db.GetTable<BAN>().DeleteOnSubmit(ban);
                db.SubmitChanges();
            }
        }
    }
}
