using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class MoBanRepository
    {
        // Lấy các bàn đang hoạt động và chưa có khách sử dụng
        public List<BAN> LayDanhSachBan()
        {
            using (var db = DbFactory.Create())
            {
                return db.BANs.Where(b => b.HoatDong && !db.LUOTBANs.Any(lb => lb.MaBan == b.MaBan && lb.DenLuc == null)).OrderBy(b => b.TenBan).ToList();
            }
        }

        // Lấy lượt đặt đang chờ của bàn được chọn
        public List<DatBanDTO> LayDatBanTheoBan(int maBan)
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from datBan in db.DATBANs
                    join ban in db.BANs on datBan.MaBan equals ban.MaBan
                    where datBan.MaBan == maBan && datBan.TrangThai == "CHO"
                    orderby datBan.GioDen
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

        // Chỉ lấy gói đang bán và có ít nhất một món đang bán
        public List<GOIBUFFET> LayDanhSachGoiBuffet()
        {
            using (var db = DbFactory.Create())
            {
                return db.GOIBUFFETs.Where(g => g.DangBan && (
                    from gm in db.GOIBUFFET_MONs
                    join mon in db.MONANs on gm.MaMon equals mon.MaMon
                    where gm.MaGoi == g.MaGoi && mon.DangBan
                    select gm.MaMon).Any()).OrderBy(g => g.GiaNguoiLon).ThenBy(g => g.TenGoi).ToList();
            }
        }

        // Tạo lượt, gắn bàn và lưu giá vé trong cùng transaction.
        public int MoBan(MoBanDTO input, int maND)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaBan(db, input.MaBan);
                var ban = db.BANs.SingleOrDefault(x => x.MaBan == input.MaBan);
                if (ban == null || !ban.HoatDong)
                    throw new InvalidOperationException("Bàn không còn hoạt động.");
                if (db.LUOTBANs.Any(x => x.MaBan == ban.MaBan && x.DenLuc == null))
                    throw new InvalidOperationException("Bàn đã có khách. Hãy tải lại.");
                var dat = db.DATBANs.Where(x => x.MaBan == ban.MaBan && x.TrangThai == "CHO").ToList();
                if (dat.Count > 1)
                    throw new InvalidOperationException("Bàn có nhiều lượt đặt chờ. Hãy xử lý các lượt trùng trước.");
                if (input.MaDatBan.HasValue)
                {
                    var d = dat.SingleOrDefault(x => x.MaDatBan == input.MaDatBan.Value);
                    if (d == null || db.LUOTPHUCVUs.Any(x => x.MaDatBan == d.MaDatBan))
                        throw new InvalidOperationException("Lượt đặt không còn hợp lệ.");
                    if (d.SoKhach > ban.SoCho)
                        throw new InvalidOperationException("Bàn không đủ số chỗ cho lượt đặt.");
                    d.TrangThai = "DA_DEN";
                }
                else if (dat.Count > 0)
                    throw new InvalidOperationException("Bàn đã đặt trước. Phải chọn đúng lượt đặt.");
                GOIBUFFET goi = null;
                if (input.HinhThuc == "BUFFET")
                {
                    if (input.TongKhachBuffet > ban.SoCho)
                        throw new InvalidOperationException("Số khách vượt số chỗ của bàn.");
                    goi = db.GOIBUFFETs.SingleOrDefault(x => x.MaGoi == input.MaGoi && x.DangBan);
                    if (goi == null || !(
                        from gm in db.GOIBUFFET_MONs
                        join m in db.MONANs on gm.MaMon equals m.MaMon
                        where gm.MaGoi == goi.MaGoi && m.DangBan
                        select m.MaMon).Any())
                        throw new InvalidOperationException("Gói buffet không còn bán hoặc chưa có món đang bán.");
                    // Đây là cấu hình nghiệp vụ cố định, không phải dữ liệu khách hàng mẫu.
                    var rates = new[]
                    {
                        0m,
                        0.5m,
                        1m
                    };
                    for (int i = 1; i <= 3; i++)
                    {
                        var n = db.NHOMCHIEUCAOs.SingleOrDefault(x => x.MaNhom == i);
                        if (n == null)
                            db.NHOMCHIEUCAOs.InsertOnSubmit(new NHOMCHIEUCAO { MaNhom = i, TenNhom = i == 1 ? "Dưới 1 m" : i == 2 ? "Từ 1 m đến dưới 1,3 m" : "Từ 1,3 m", TuCm = i == 1 ? 0 : i == 2 ? 100 : 130, DenCm = i == 1 ? (int? )100 : i == 2 ? (int? )130 : null, TyLeThu = rates[i - 1] });
                        else if (n.TyLeThu != rates[i - 1])
                            throw new InvalidOperationException("Cấu hình nhóm chiều cao không hợp lệ.");
                    }

                    db.SubmitChanges();
                }

                var now = DateTime.Now;
                var luot = new LUOTPHUCVU
                {
                    MaND = maND,
                    MaDatBan = input.MaDatBan,
                    HinhThuc = input.HinhThuc,
                    MaGoi = goi == null ? (int? )null : goi.MaGoi,
                    GioMo = now,
                    GiaPhatMoiKg = goi == null ? (decimal? )null : goi.DonGiaPhatMoiKg,
                    TrangThai = "DANG_PHUC_VU"
                };
                db.LUOTPHUCVUs.InsertOnSubmit(luot);
                db.SubmitChanges();
                db.LUOTBANs.InsertOnSubmit(new LUOTBAN { MaLuot = luot.MaLuot, MaBan = ban.MaBan, TuLuc = now });
                if (goi != null)
                {
                    var counts = new[]
                    {
                        input.SoKhachDuoi1m,
                        input.SoKhachTu1mDenDuoi1m3,
                        input.SoKhachTu1m3
                    };
                    var rates = new[]
                    {
                        0m,
                        0.5m,
                        1m
                    };
                    for (int i = 0; i < 3; i++)
                        if (counts[i] > 0)
                            db.VEBUFFETs.InsertOnSubmit(new VEBUFFET { MaLuot = luot.MaLuot, MaNhom = i + 1, SoKhach = counts[i], GiaNguoiLon = goi.GiaNguoiLon, TyLeThu = rates[i] });
                }

                db.SubmitChanges();
                scope.Complete();
                return luot.MaLuot;
            }
        }
    }
}
