using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    public class BaoCaoDoanhThuDTO
    {
        // Thông tin điều kiện lọc để hiển thị trên báo cáo.
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string HinhThuc { get; set; }

        // Danh sách hóa đơn sau khi lọc, đưa vào ReportDataSource.
        public DataTable DanhSach { get; set; }

        // Tổng doanh thu tính bằng LINQ Sum.
        public decimal TongDoanhThu { get; set; }
    }
}
