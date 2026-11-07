using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Chứa dữ liệu phục vụ màn hình quản lý tài khoản
    public class TaiKhoanDTO
    {
        public int MaND { get; set; }
        public string MaTaiKhoan { get; set; }
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }
        public bool HoatDong { get; set; }
    }
}
