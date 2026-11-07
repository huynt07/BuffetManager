using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class HoaDonRepository
    {
        // Dự toán và hóa đơn dùng chung công thức, làm tròn từng dòng theo SQL.
        internal List<ChiTietHoaDonDTO> ChiTiet(BuffetDataContext db, int root, decimal kg)
        {
            var ids = NghiepVuHelper.CacLuot(db, root);
            var result = new List<ChiTietHoaDonDTO>();
            var ve = (
                from v in db.VEBUFFETs
                join n in db.NHOMCHIEUCAOs on v.MaNhom equals n.MaNhom
                where ids.Contains(v.MaLuot)select new
                {
                    v,
                    n.TenNhom
                }

            ).ToList();
            foreach (var x in ve)
                result.Add(new ChiTietHoaDonDTO { LoaiDong = "VE", MaVe = x.v.MaVe, TenDong = "Vé buffet - " + x.TenNhom, DonVi = "Vé", SoLuong = x.v.SoKhach, DonGia = x.v.DonGia ?? Math.Round(x.v.GiaNguoiLon * x.v.TyLeThu, 2, MidpointRounding.AwayFromZero) });
            var combos = (
                from c in db.LUACHONCOMBOs
                join m in db.COMBOs on c.MaCombo equals m.MaCombo
                where ids.Contains(c.MaLuot)select new
                {
                    c,
                    m.TenCombo
                }

            ).ToList();
            foreach (var x in combos)
            {
                if (!db.CHITIETGOIMONs.Any(d => d.MaChonCombo == x.c.MaChonCombo && d.TrangThai != "HUY"))
                    continue;
                result.Add(new ChiTietHoaDonDTO { LoaiDong = "COMBO", MaChonCombo = x.c.MaChonCombo, TenDong = x.TenCombo, DonVi = "Combo", SoLuong = x.c.SoLuong, DonGia = x.c.DonGia });
            }

            var mon = (
                from c in db.CHITIETGOIMONs
                join m in db.MONANs on c.MaMon equals m.MaMon
                where ids.Contains(c.MaLuot) && c.TrangThai != "HUY" && (c.Nguon == "GOI_THEM" || c.Nguon == "GOIMON")select new
                {
                    c,
                    m.TenMon,
                    m.DonVi
                }

            ).ToList();
            foreach (var x in mon)
                result.Add(new ChiTietHoaDonDTO { LoaiDong = "MON", MaCTG = x.c.MaCTG, TenDong = (x.c.Nguon == "GOI_THEM" ? "Gọi thêm: " : "") + x.TenMon, DonVi = x.DonVi, SoLuong = x.c.SoLuong, DonGia = x.c.DonGia });
            var l = db.LUOTPHUCVUs.Single(x => x.MaLuot == root);
            if (kg > 0 && l.HinhThuc == "BUFFET")
                result.Add(new ChiTietHoaDonDTO { LoaiDong = "PHAT_THUA", TenDong = "Phạt đồ ăn thừa", DonVi = "kg", SoLuong = kg, DonGia = l.GiaPhatMoiKg ?? 0 });
            return result;
        }

        public List<ChiTietHoaDonDTO> DuTinh(int id, decimal kg)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaLuot(db, id);
                NghiepVuHelper.DangPhucVu(db, id);
                var r = ChiTiet(db, id, kg);
                scope.Complete();
                return r;
            }
        }

        public int ThanhToan(ThanhToanDTO input, int maND)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaLuot(db, input.MaLuot);
                var l = NghiepVuHelper.DangPhucVu(db, input.MaLuot);
                if (db.HOADONs.Any(x => x.MaLuot == l.MaLuot))
                    throw new InvalidOperationException("Lượt đã có hóa đơn.");
                if (input.KhoiLuongThua > 0 && l.HinhThuc != "BUFFET")
                    throw new InvalidOperationException("Chỉ buffet áp dụng phạt đồ thừa.");
                var ids = NghiepVuHelper.CacLuot(db, l.MaLuot);
                if (db.CHITIETGOIMONs.Any(x => ids.Contains(x.MaLuot) && x.TrangThai != "DA_PHUC_VU" && x.TrangThai != "HUY"))
                    throw new InvalidOperationException("Còn món chưa phục vụ. Hãy xử lý phiếu trước khi thanh toán.");
                var lines = ChiTiet(db, l.MaLuot, input.KhoiLuongThua);
                if (lines.Count == 0)
                    throw new InvalidOperationException("Lượt chưa có vé hoặc món tính tiền. Hãy gọi món trước.");
                if (l.HinhThuc == "COMBO" && !lines.Any(x => x.LoaiDong == "COMBO"))
                    throw new InvalidOperationException("Lượt combo phải có ít nhất một combo chưa bị hủy.");
                decimal total = lines.Sum(x => x.ThanhTien);
                if (total != input.TongTienDaXem)
                    throw new InvalidOperationException("Hóa đơn đã thay đổi. Hãy đóng rồi mở lại màn hình thanh toán để kiểm tra.");
                decimal received = input.PhuongThuc == "CHUYENKHOAN" ? total : input.TienKhachDua;
                if (received < total)
                    throw new InvalidOperationException("Tiền khách đưa chưa đủ.");
                string tables = NghiepVuHelper.TenBan(db, l.MaLuot);
                if (string.IsNullOrEmpty(tables) || tables.Length > 255)
                    throw new InvalidOperationException("Tên nhóm bàn trống hoặc quá dài để lưu hóa đơn.");
                var now = DateTime.Now;
                var hd = new HOADON
                {
                    MaLuot = l.MaLuot,
                    MaND = maND,
                    NgayLap = now,
                    HinhThuc = l.HinhThuc,
                    TenBanSnapshot = tables,
                    PhuongThuc = input.PhuongThuc,
                    TongTien = total,
                    TienKhachDua = received
                };
                db.HOADONs.InsertOnSubmit(hd);
                db.SubmitChanges();
                foreach (var d in lines)
                    db.CHITIETHOADONs.InsertOnSubmit(new CHITIETHOADON { MaHD = hd.MaHD, LoaiDong = d.LoaiDong, MaVe = d.MaVe, MaChonCombo = d.MaChonCombo, MaCTG = d.MaCTG, TenDong = d.TenDong, DonVi = d.DonVi, SoLuong = d.SoLuong, DonGia = d.DonGia });
                foreach (var b in db.LUOTBANs.Where(x => x.MaLuot == l.MaLuot && x.DenLuc == null))
                    b.DenLuc = now;
                l.TrangThai = "DA_THANH_TOAN";
                l.GioDong = now;
                db.SubmitChanges();
                scope.Complete();
                return hd.MaHD;
            }
        }

        public List<HoaDonDTO> DanhSach(DateTime tu, DateTime den, string hinhThuc, int page, int size, out int count, out decimal total)
        {
            using (var db = DbFactory.Create())
            {
                var q = db.HOADONs.Where(x => x.NgayLap >= tu && x.NgayLap < den);
                if (!string.IsNullOrEmpty(hinhThuc))
                    q = q.Where(x => x.HinhThuc == hinhThuc);
                count = q.Count();
                total = q.Sum(x => (decimal? )x.TongTien) ?? 0;
                return q.OrderByDescending(x => x.NgayLap).ThenByDescending(x => x.MaHD).Skip((page - 1) * size).Take(size).Select(x => new HoaDonDTO { MaHD = x.MaHD, MaLuot = x.MaLuot, NgayLap = x.NgayLap, TenBan = x.TenBanSnapshot, HinhThuc = x.HinhThuc, PhuongThuc = x.PhuongThuc, TongTien = x.TongTien, TienKhachDua = x.TienKhachDua, TienThua = x.TienThua ?? 0 }).ToList();
            }
        }

        public List<ChiTietHoaDonDTO> ChiTietDaLuu(int id)
        {
            using (var db = DbFactory.Create())
                return db.CHITIETHOADONs.Where(x => x.MaHD == id).OrderBy(x => x.MaCTHD).Select(x => new ChiTietHoaDonDTO { LoaiDong = x.LoaiDong, MaVe = x.MaVe, MaChonCombo = x.MaChonCombo, MaCTG = x.MaCTG, TenDong = x.TenDong, DonVi = x.DonVi, SoLuong = x.SoLuong, DonGia = x.DonGia }).ToList();
        }
    }
}
