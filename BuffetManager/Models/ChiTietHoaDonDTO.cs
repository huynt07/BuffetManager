using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class ChiTietHoaDonDTO
    {
        public string LoaiDong { get; set; }
        public int? MaVe { get; set; }
        public int? MaChonCombo { get; set; }
        public int? MaCTG { get; set; }
        public string TenDong { get; set; }
        public string DonVi { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien
        {
            get
            {
                return Math.Round(SoLuong * DonGia, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
