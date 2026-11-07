using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class ThanhToanDTO
    {
        public int MaLuot { get; set; }
        public decimal KhoiLuongThua { get; set; }
        public string PhuongThuc { get; set; }
        public decimal TienKhachDua { get; set; }
        public bool DaNhanChuyenKhoan { get; set; }
        // Tổng tiền người dùng đã xem; chặn thanh toán nếu dữ liệu vừa thay đổi.
        public decimal TongTienDaXem { get; set; }
    }
}
