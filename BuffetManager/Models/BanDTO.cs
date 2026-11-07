    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu hiển thị trên màn hình quản lý bàn
    public class BanDTO
    {
        public int MaBan { get; set; }
        public int MaKV { get; set; }
        public string TenBan { get; set; }
        public string TenKV { get; set; }
        public int SoCho { get; set; }
        public bool HoatDong { get; set; }
    }
}
