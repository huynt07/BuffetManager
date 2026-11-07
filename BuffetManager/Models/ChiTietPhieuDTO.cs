using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class ChiTietPhieuDTO
    {
        public int MaCTG { get; set; }
        public int MaPG { get; set; }
        public int MaLuot { get; set; }
        public string TenBan { get; set; }
        public string TenMon { get; set; }
        public string BoPhan { get; set; }
        public string Nguon { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }
        public DateTime GioGoi { get; set; }
        public string GhiChu { get; set; }
        public int? MaChonCombo { get; set; }
    }
}
