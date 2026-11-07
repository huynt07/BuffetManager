using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class GoiMonDTO
    {
        public int MaLuot { get; set; }
        public string GhiChu { get; set; }
        public List<DongGoiMonDTO> ChiTiet { get; set; } = new List<DongGoiMonDTO>();
    }
}
