using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class GoiMonRepository
    {
        public List<ThucDonDTO> ThucDon(int maLuot, string loai, string tim)
        {
            using (var db = DbFactory.Create())
            {
                var l = NghiepVuHelper.DangPhucVu(db, maLuot);
                tim = (tim ?? "").Trim();
                if (loai == "COMBO")
                {
                    if (l.HinhThuc != "COMBO")
                        return new List<ThucDonDTO>();
                    return db.COMBOs.Where(c => c.DangBan && c.TenCombo.Contains(tim) && db.COMBO_MONs.Any(cm => cm.MaCombo == c.MaCombo)).OrderBy(c => c.TenCombo).Select(c => new ThucDonDTO { Ma = c.MaCombo, Loai = "COMBO", Ten = c.TenCombo, DonVi = "Combo", DonGia = c.GiaCombo }).ToList();
                }

                var q = db.MONANs.Where(m => m.DangBan && m.TenMon.Contains(tim));
                if (l.HinhThuc == "BUFFET")
                    q = q.Where(m => db.GOIBUFFET_MONs.Any(g => g.MaGoi == l.MaGoi && g.MaMon == m.MaMon));
                bool free = l.HinhThuc == "BUFFET";
                return q.OrderBy(m => m.TenMon).Select(m => new ThucDonDTO { Ma = m.MaMon, Loai = "MON", Ten = m.TenMon, DonVi = m.DonVi, DonGia = free ? 0 : m.GiaLe }).ToList();
            }
        }

        private CHITIETGOIMON TaoMon(BuffetDataContext db, LUOTPHUCVU luot, int maPG, int maMon, int qty, string nguon, int? combo)
        {
            var m = db.MONANs.SingleOrDefault(x => x.MaMon == maMon && x.DangBan);
            if (m == null)
                throw new InvalidOperationException("Món mã " + maMon + " không còn bán.");
            if (nguon == "BUFFET" && !db.GOIBUFFET_MONs.Any(x => x.MaGoi == luot.MaGoi && x.MaMon == maMon))
                throw new InvalidOperationException("Món không thuộc gói buffet.");
            var dept = db.DANHMUCMONs.Single(x => x.MaDM == m.MaDM).BoPhan;
            return new CHITIETGOIMON
            {
                MaPG = maPG,
                MaLuot = luot.MaLuot,
                MaMon = maMon,
                MaChonCombo = combo,
                Nguon = nguon,
                BoPhan = dept,
                SoLuong = qty,
                DonGia = (nguon == "BUFFET" || nguon == "TRONG_COMBO") ? 0 : m.GiaLe,
                TrangThai = "CHO"
            };
        }

        public int Gui(GoiMonDTO input, int maND)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                NghiepVuHelper.KhoaLuot(db, input.MaLuot);
                var l = NghiepVuHelper.DangPhucVu(db, input.MaLuot);
                // Món gọi thêm phải đi kèm ít nhất một combo chưa bị hủy.
                if (l.HinhThuc == "COMBO" && !input.ChiTiet.Any(x => x.Loai == "COMBO"))
                {
                    var ids = NghiepVuHelper.CacLuot(db, l.MaLuot);
                    if (!db.CHITIETGOIMONs.Any(x => ids.Contains(x.MaLuot)
                        && x.Nguon == "TRONG_COMBO" && x.TrangThai != "HUY"))
                        throw new InvalidOperationException("Hãy chọn ít nhất một combo trước khi gọi thêm món lẻ.");
                }
                var phieu = new PHIEUGOIMON
                {
                    MaLuot = l.MaLuot,
                    MaND = maND,
                    GioGoi = DateTime.Now,
                    GhiChu = input.GhiChu
                };
                db.PHIEUGOIMONs.InsertOnSubmit(phieu);
                db.SubmitChanges();
                var lines = new List<CHITIETGOIMON>();
                foreach (var d in input.ChiTiet)
                {
                    if (d.Loai == "COMBO")
                    {
                        if (l.HinhThuc != "COMBO")
                            throw new InvalidOperationException("Chỉ lượt COMBO được chọn combo.");
                        var c = db.COMBOs.SingleOrDefault(x => x.MaCombo == d.Ma && x.DangBan);
                        if (c == null)
                            throw new InvalidOperationException("Combo không còn bán.");
                        if (c.GiaCombo != d.DonGia)
                            throw new InvalidOperationException("Giá combo đã thay đổi. Hãy xóa dòng và chọn lại.");
                        var parts = db.COMBO_MONs.Where(x => x.MaCombo == c.MaCombo).ToList();
                        if (parts.Count == 0)
                            throw new InvalidOperationException("Combo chưa có món thành phần.");
                        var choice = new LUACHONCOMBO
                        {
                            MaLuot = l.MaLuot,
                            MaCombo = c.MaCombo,
                            SoLuong = d.SoLuong,
                            DonGia = c.GiaCombo
                        };
                        db.LUACHONCOMBOs.InsertOnSubmit(choice);
                        db.SubmitChanges();
                        foreach (var part in parts)
                            lines.Add(TaoMon(db, l, phieu.MaPG, part.MaMon, checked(part.SoLuong * d.SoLuong), "TRONG_COMBO", choice.MaChonCombo));
                    }
                    else
                    {
                        var line = TaoMon(db, l, phieu.MaPG, d.Ma, d.SoLuong, l.HinhThuc == "BUFFET" ? "BUFFET" : l.HinhThuc == "COMBO" ? "GOI_THEM" : "GOIMON", null);
                        if (line.DonGia != d.DonGia)
                            throw new InvalidOperationException("Giá món đã thay đổi. Hãy xóa dòng và chọn lại.");
                        lines.Add(line);
                    }
                }

                db.CHITIETGOIMONs.InsertAllOnSubmit(lines);
                db.SubmitChanges();
                // Tính tổng nhu cầu của cả phiếu trước khi trừ; món trùng nguyên liệu được cộng dồn.
                var needs = new List<BIENDONGKHO>();
                foreach (var line in lines)
                {
                    var recipe = db.DINHLUONGs.Where(x => x.MaMon == line.MaMon).ToList();
                    if (recipe.Count == 0)
                        throw new InvalidOperationException("Món mã " + line.MaMon + " chưa có định lượng.");
                    foreach (var r in recipe)
                        needs.Add(new BIENDONGKHO { MaNL = r.MaNL, MaCTG = line.MaCTG, MaND = maND, NgayGhi = phieu.GioGoi, Loai = "XUAT", SoLuong = -r.LuongCan * line.SoLuong });
                }

                foreach (var g in needs.GroupBy(x => x.MaNL).OrderBy(x => x.Key))
                {
                    db.ExecuteQuery<int>("SELECT MaNL FROM dbo.NGUYENLIEU WITH (UPDLOCK,HOLDLOCK) WHERE MaNL={0}", g.Key).ToList();
                    var nl = db.NGUYENLIEUs.Single(x => x.MaNL == g.Key);
                    decimal can = -g.Sum(x => x.SoLuong);
                    if (nl.TonKho < can)
                        throw new InvalidOperationException("Không đủ " + nl.TenNL + ". Cần " + can + " " + nl.DonVi + ", còn " + nl.TonKho + ".");
                    if (lines.Where(x => g.Any(n => n.MaCTG == x.MaCTG)).Any(x => x.BoPhan != nl.BoPhan))
                        throw new InvalidOperationException("Định lượng khác bộ phận với món.");
                    nl.TonKho -= can;
                }

                db.BIENDONGKHOs.InsertAllOnSubmit(needs);
                db.SubmitChanges();
                scope.Complete();
                return phieu.MaPG;
            }
        }
    }
}
