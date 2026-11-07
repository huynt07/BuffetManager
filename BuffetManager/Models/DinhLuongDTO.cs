using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu hiển thị nguyên liệu cần cho một đơn vị món
    public class DinhLuongDTO
    {
        public int MaMon { get; set; }
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public string DonVi { get; set; }
        public decimal LuongCan { get; set; }
    }
}
