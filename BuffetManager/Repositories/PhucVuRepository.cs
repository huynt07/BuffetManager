using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class PhucVuRepository
    {
        public List<KHUVUC> KhuVuc()
        {
            using (var db = DbFactory.Create())
                return db.KHUVUCs.OrderBy(x => x.TenKV).ToList();
        }

        public List<BanPhucVuDTO> DanhSach()
        {
            using (var db = DbFactory.Create())
            {
                var bans = (
                    from b in db.BANs
                    join k in db.KHUVUCs on b.MaKV equals k.MaKV
                    where b.HoatDong
                    orderby k.TenKV, b.TenBan
                    select new BanPhucVuDTO
                    {
                        MaBan = b.MaBan,
                        MaKV = b.MaKV,
                        TenBan = b.TenBan,
                        TenKV = k.TenKV,
                        SoCho = b.SoCho
                    }

                ).ToList();
                var active = (
                    from lb in db.LUOTBANs
                    join l in db.LUOTPHUCVUs on lb.MaLuot equals l.MaLuot
                    where lb.DenLuc == null
                    select new
                    {
                        lb.MaBan,
                        l.MaLuot,
                        l.HinhThuc
                    }

                ).ToList();
                var booked = db.DATBANs.Where(x => x.TrangThai == "CHO").Select(x => x.MaBan).ToList();
                foreach (var b in bans)
                {
                    var a = active.FirstOrDefault(x => x.MaBan == b.MaBan);
                    b.MaLuot = a == null ? (int? )null : a.MaLuot;
                    b.HinhThuc = a == null ? "" : a.HinhThuc;
                    b.TrangThai = a != null ? "Đang phục vụ" : booked.Contains(b.MaBan) ? "Đã đặt" : "Trống";
                }

                return bans;
            }
        }

        public LUOTPHUCVU Luot(int id)
        {
            using (var db = DbFactory.Create())
                return NghiepVuHelper.DangPhucVu(db, id);
        }

        public string TenBan(int id)
        {
            using (var db = DbFactory.Create())
                return NghiepVuHelper.TenBan(db, id);
        }

        // Giải phóng lượt mở nhầm hoặc lượt chỉ có các món đã hủy; không xóa lịch sử.
        public void HuyLuot(int id)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaLuot(db, id);
                var l = NghiepVuHelper.DangPhucVu(db, id);
                var ids = NghiepVuHelper.CacLuot(db, id);
                if (db.HOADONs.Any(x => ids.Contains(x.MaLuot)) || db.CHITIETGOIMONs.Any(x => ids.Contains(x.MaLuot) && x.TrangThai != "HUY"))
                    throw new InvalidOperationException("Chỉ hủy lượt chưa gọi món hoặc tất cả món đã được hủy trước khi làm.");
                var now = DateTime.Now;
                foreach (var b in db.LUOTBANs.Where(x => x.MaLuot == id && x.DenLuc == null))
                    b.DenLuc = now;
                l.TrangThai = "HUY";
                l.GioDong = now;
                db.SubmitChanges();
                scope.Complete();
            }
        }
    }
}
