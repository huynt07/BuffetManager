using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu hiển thị trên màn hình quản lý món ăn
    public class MonAnDTO
    {
        public int MaMon { get; set; }
        public int MaDM { get; set; }
        public string TenMon { get; set; }
        public string TenDM { get; set; }
        public string DonVi { get; set; }
        public decimal GiaLe { get; set; }
        public bool DangBan { get; set; }
    }
}
