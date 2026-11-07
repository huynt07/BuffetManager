using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu hiển thị món trong một combo
    public class ComboMonDTO
    {
        public int MaCombo { get; set; }
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public string DonVi { get; set; }
        public int SoLuong { get; set; }
        public bool DangBan { get; set; }
    }
}
