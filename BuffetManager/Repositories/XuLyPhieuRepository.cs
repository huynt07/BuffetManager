using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class XuLyPhieuRepository
    {
        public List<ChiTietPhieuDTO> DanhSach(string boPhan, string trangThai)
        {
            using (var db = DbFactory.Create())
            {
                var q =
                    from ct in db.CHITIETGOIMONs
                    join p in db.PHIEUGOIMONs on ct.MaPG equals p.MaPG
                    join m in db.MONANs on ct.MaMon equals m.MaMon
                    where ct.BoPhan == boPhan && (trangThai == "" || ct.TrangThai == trangThai)orderby p.GioGoi, ct.MaCTG
                    select new ChiTietPhieuDTO
                    {
                        MaCTG = ct.MaCTG,
                        MaPG = p.MaPG,
                        MaLuot = ct.MaLuot,
                        TenMon = m.TenMon,
                        BoPhan = ct.BoPhan,
                        Nguon = ct.Nguon,
                        SoLuong = ct.SoLuong,
                        TrangThai = ct.TrangThai,
                        GioGoi = p.GioGoi,
                        GhiChu = p.GhiChu,
                        MaChonCombo = ct.MaChonCombo
                    };
                var list = q.ToList();
                var result = new List<ChiTietPhieuDTO>();
                foreach (var group in list.GroupBy(x => x.MaLuot))
                {
                    int root = NghiepVuHelper.Goc(db, group.Key);
                    if (!db.LUOTPHUCVUs.Any(x => x.MaLuot == root && x.TrangThai == "DANG_PHUC_VU"))
                        continue;
                    string ban = NghiepVuHelper.TenBan(db, root);
                    foreach (var d in group)
                    {
                        d.TenBan = ban;
                        result.Add(d);
                    }
                }

                return result.OrderBy(x => x.GioGoi).ThenBy(x => x.MaCTG).ToList();
            }
        }

        public void CapNhat(int id, string dept, string action, int maND, bool choHuyCombo)
        {
            using (var scope = NghiepVuHelper.Transaction())
            using (var db = DbFactory.Create())
            {
                // Đọc không theo dõi trước khi khóa; sau khóa mới lấy entity cần cập nhật.
                int? original = db.CHITIETGOIMONs.Where(x => x.MaCTG == id).Select(x => (int? )x.MaLuot).SingleOrDefault();
                if (!original.HasValue)
                    throw new InvalidOperationException("Không tìm thấy dòng món.");
                int root = NghiepVuHelper.Goc(db, original.Value);
                NghiepVuHelper.KhoaLuot(db, root);
                NghiepVuHelper.DangPhucVu(db, root);
                var line = db.CHITIETGOIMONs.Single(x => x.MaCTG == id);
                if (line.BoPhan != dept)
                    throw new UnauthorizedAccessException("Món không thuộc bộ phận đang xử lý.");
                if (action == "HUY")
                {
                    var lines = new List<CHITIETGOIMON>
                    {
                        line
                    };
                    if (line.MaChonCombo.HasValue)
                    {
                        if (!choHuyCombo)
                            throw new UnauthorizedAccessException("Hủy cả combo cần quyền gọi món (Phục vụ/Admin).");
                        lines = db.CHITIETGOIMONs.Where(x => x.MaChonCombo == line.MaChonCombo).ToList();
                    }

                    if (lines.Any(x => x.TrangThai != "CHO"))
                        throw new InvalidOperationException("Chỉ hủy khi tất cả món liên quan chưa bắt đầu làm.");
                    var ids = lines.Select(x => x.MaCTG).ToList();
                    if (db.BIENDONGKHOs.Any(x => x.MaCTG.HasValue && ids.Contains(x.MaCTG.Value) && x.Loai == "HOAN"))
                        throw new InvalidOperationException("Món đã được hoàn kho.");
                    var exports = db.BIENDONGKHOs.Where(x => x.MaCTG.HasValue && ids.Contains(x.MaCTG.Value) && x.Loai == "XUAT").ToList();
                    // Hoàn theo sổ xuất thực tế, không theo định lượng có thể đã sửa.
                    foreach (var g in exports.GroupBy(x => x.MaNL).OrderBy(x => x.Key))
                    {
                        db.ExecuteQuery<int>("SELECT MaNL FROM dbo.NGUYENLIEU WITH (UPDLOCK,HOLDLOCK) WHERE MaNL={0}", g.Key).ToList();
                        db.NGUYENLIEUs.Single(x => x.MaNL == g.Key).TonKho -= g.Sum(x => x.SoLuong);
                    }

                    foreach (var e in exports)
                        db.BIENDONGKHOs.InsertOnSubmit(new BIENDONGKHO { MaNL = e.MaNL, MaCTG = e.MaCTG, MaND = maND, NgayGhi = DateTime.Now, Loai = "HOAN", SoLuong = -e.SoLuong });
                    foreach (var d in lines)
                        d.TrangThai = "HUY";
                }
                else
                {
                    string expected = action == "DANG_LAM" ? "CHO" : action == "DA_XONG" ? "DANG_LAM" : action == "DA_PHUC_VU" ? "DA_XONG" : null;
                    if (expected == null || line.TrangThai != expected)
                        throw new InvalidOperationException("Trạng thái đã thay đổi hoặc thao tác không đúng thứ tự. Hãy tải lại.");
                    line.TrangThai = action;
                }

                db.SubmitChanges();
                scope.Complete();
            }
        }
    }
}
