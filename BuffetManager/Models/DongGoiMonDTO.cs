using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class DongGoiMonDTO
    {
        public int Ma { get; set; }
        public string Loai { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}
