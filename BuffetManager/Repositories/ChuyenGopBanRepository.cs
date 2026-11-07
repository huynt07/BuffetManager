using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class ChuyenGopBanRepository
    {
        public void ThucHien(ChuyenGopBanDTO input)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                // Khóa các bàn theo mã tăng dần để giảm tranh chấp khi hai máy thao tác.
                foreach (var id in new[]
                {
                    input.MaBanNguon,
                    input.MaBanDich
                }.OrderBy(x => x))
                    NghiepVuHelper.KhoaBan(db, id);
                var source = db.LUOTBANs.SingleOrDefault(x => x.MaBan == input.MaBanNguon && x.DenLuc == null);
                if (source == null || source.MaLuot != input.MaLuotNguon)
                    throw new InvalidOperationException("Bàn nguồn đã thay đổi. Hãy tải lại.");
                var dest = db.BANs.SingleOrDefault(x => x.MaBan == input.MaBanDich && x.HoatDong);
                if (dest == null)
                    throw new InvalidOperationException("Bàn đích không hoạt động.");
                var occupied = db.LUOTBANs.SingleOrDefault(x => x.MaBan == dest.MaBan && x.DenLuc == null);
                var lockIds = new[]
                {
                    source.MaLuot,
                    occupied == null ? source.MaLuot : occupied.MaLuot
                }.Distinct().OrderBy(x => x);
                foreach (var id in lockIds)
                    NghiepVuHelper.KhoaLuot(db, id);
                var src = NghiepVuHelper.DangPhucVu(db, source.MaLuot);
                var now = DateTime.Now;
                if (input.ThaoTac == "CHUYEN")
                {
                    if (occupied != null || db.DATBANs.Any(x => x.MaBan == dest.MaBan && x.TrangThai == "CHO"))
                        throw new InvalidOperationException("Bàn đích phải trống và chưa được đặt.");
                    var oldBan = db.BANs.Single(x => x.MaBan == source.MaBan);
                    if (dest.SoCho < oldBan.SoCho)
                        throw new InvalidOperationException("Chọn bàn đích có số chỗ ít nhất bằng bàn nguồn.");
                    source.DenLuc = now;
                    db.SubmitChanges();
                    db.LUOTBANs.InsertOnSubmit(new LUOTBAN { MaLuot = src.MaLuot, MaBan = dest.MaBan, TuLuc = now });
                }
                else
                {
                    if (occupied == null || occupied.MaLuot == src.MaLuot)
                        throw new InvalidOperationException("Chọn bàn thuộc một lượt đang phục vụ khác.");
                    var target = NghiepVuHelper.DangPhucVu(db, occupied.MaLuot);
                    if (src.HinhThuc != target.HinhThuc || src.MaGoi != target.MaGoi || src.GiaPhatMoiKg != target.GiaPhatMoiKg)
                        throw new InvalidOperationException("Chỉ gộp cùng hình thức; buffet phải cùng gói và giá phạt.");
                    if (src.HinhThuc == "BUFFET")
                    {
                        var a = NghiepVuHelper.CacLuot(db, src.MaLuot);
                        var b = NghiepVuHelper.CacLuot(db, target.MaLuot);
                        var prices = db.VEBUFFETs.Where(x => a.Contains(x.MaLuot) || b.Contains(x.MaLuot)).Select(x => x.GiaNguoiLon).Distinct().ToList();
                        if (prices.Count != 1)
                            throw new InvalidOperationException("Hai lượt buffet có giá vé khác nhau, không thể gộp.");
                    }

                    // Gộp hóa đơn và nhóm bàn; khách vẫn sử dụng tất cả bàn hiện tại.
                    var tables = db.LUOTBANs.Where(x => x.MaLuot == src.MaLuot && x.DenLuc == null).ToList();
                    foreach (var t in tables)
                        t.DenLuc = now;
                    db.SubmitChanges();
                    foreach (var t in tables)
                        db.LUOTBANs.InsertOnSubmit(new LUOTBAN { MaLuot = target.MaLuot, MaBan = t.MaBan, TuLuc = now });
                    src.TrangThai = "DA_GOP";
                    src.GioDong = now;
                    src.GopVaoMaLuot = target.MaLuot;
                }

                db.SubmitChanges();
                scope.Complete();
            }
        }
    }
}
