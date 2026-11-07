using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu biểu đồ Top 5 món.
    public class TopMonDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal SoLuong { get; set; }
    }

    // Dữ liệu doanh thu từng tháng.
    public class DoanhThuThangDTO
    {
        public int Thang { get; set; }
        public decimal DoanhThu { get; set; }
    }

    // Dữ liệu doanh thu theo hình thức dùng bữa.
    public class DoanhThuHinhThucDTO
    {
        public string HinhThuc { get; set; }
        public decimal DoanhThu { get; set; }
    }
}
