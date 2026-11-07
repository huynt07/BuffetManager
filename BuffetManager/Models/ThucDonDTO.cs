using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class ThucDonDTO
    {
        public int Ma { get; set; }
        public string Loai { get; set; }
        public string Ten { get; set; }
        public string DonVi { get; set; }
        public decimal DonGia { get; set; }
    }
}
