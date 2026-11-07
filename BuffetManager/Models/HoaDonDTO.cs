using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaLuot { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenBan { get; set; }
        public string HinhThuc { get; set; }
        public string PhuongThuc { get; set; }
        public decimal TongTien { get; set; }
        public decimal TienKhachDua { get; set; }
        public decimal TienThua { get; set; }
    }
}
