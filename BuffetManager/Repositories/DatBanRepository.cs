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
    public class DatBanRepository
    {
        // Lấy các bàn còn được sử dụng trong nhà hàng
        public List<BAN> LayDanhSachBan()
        {
            using (var db = DbFactory.Create())
            {
                return db.BANs.Where(b => b.HoatDong).OrderBy(b => b.TenBan).ToList();
            }
        }

        // Lấy danh sách đặt bàn, giờ đến mới nhất trước
        public List<DatBanDTO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from datBan in db.DATBANs
                    join ban in db.BANs on datBan.MaBan equals ban.MaBan
                    orderby datBan.GioDen descending, datBan.MaDatBan descending
                    select new DatBanDTO
                    {
                        MaDatBan = datBan.MaDatBan,
                        MaBan = datBan.MaBan,
                        TenBan = ban.TenBan,
                        HoTen = datBan.HoTen,
                        SDT = datBan.SDT,
                        GioDen = datBan.GioDen,
                        SoKhach = datBan.SoKhach,
                        TrangThai = datBan.TrangThai
                    };
                return query.ToList();
            }
        }

        // Lưu đặt bàn và trả về mã đặt bàn vừa tạo
        public int Them(int maBan, int maND, string hoTen, string sdt, DateTime gioDen, int soKhach)
        {
            // Các bước kiểm tra và lưu cùng một transaction
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaBan(db, maBan);
                var ban = db.BANs.SingleOrDefault(b => b.MaBan == maBan);
                if (ban == null || !ban.HoatDong)
                {
                    throw new InvalidOperationException("Bàn không tồn tại hoặc đã ngừng hoạt động.");
                }

                if (soKhach <= 0 || soKhach > ban.SoCho)
                {
                    throw new InvalidOperationException("Số khách phải từ 1 đến " + ban.SoCho + " người.");
                }

                if (gioDen <= DateTime.Now)
                {
                    throw new InvalidOperationException("Giờ đến phải sau thời điểm hiện tại.");
                }

                // CHO là lượt đặt chưa đến và chưa hủy
                bool daDuocDat = db.DATBANs.Any(d => d.MaBan == maBan && d.TrangThai == "CHO");
                if (daDuocDat)
                {
                    throw new InvalidOperationException("Bàn này đã có lượt đặt đang chờ.");
                }

                // DenLuc chưa có giá trị nghĩa là bàn vẫn đang được sử dụng
                bool dangPhucVu = db.LUOTBANs.Any(lb => lb.MaBan == maBan && lb.DenLuc == null);
                if (dangPhucVu)
                {
                    throw new InvalidOperationException("Bàn này đang phục vụ, chưa thể nhận đặt mới.");
                }

                var datBan = new DATBAN
                {
                    MaBan = maBan,
                    MaND = maND,
                    HoTen = hoTen,
                    SDT = sdt,
                    GioDen = gioDen,
                    SoKhach = soKhach,
                    TrangThai = "CHO"
                };
                db.DATBANs.InsertOnSubmit(datBan);
                db.SubmitChanges();
                // Chỉ xác nhận transaction khi mọi thao tác thành công
                scope.Complete();
                return datBan.MaDatBan;
            }
        }

        // Hủy lượt đặt đang chờ, giữ lại lịch sử
        public void Huy(int maDatBan)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                var datBan = db.DATBANs.SingleOrDefault(d => d.MaDatBan == maDatBan);
                if (datBan == null)
                {
                    throw new InvalidOperationException("Lượt đặt bàn không còn tồn tại.");
                }

                // Không hủy lượt đã đón khách hoặc đã hủy trước đó
                if (datBan.TrangThai != "CHO")
                {
                    throw new InvalidOperationException("Chỉ được hủy lượt đặt đang chờ khách.");
                }

                datBan.TrangThai = "HUY";
                db.SubmitChanges();
                scope.Complete();
            }
        }
    } // Đóng class
}
