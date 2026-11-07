using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    public class BaoCaoHoaDonDTO
    {
        // Thông tin chung: mã hóa đơn, ngày lập, bàn, hình thức...
        public HOADON HoaDon { get; set; }

        // Các dòng vé, combo, món và khoản phạt trên hóa đơn.
        public DataTable ChiTiet { get; set; }
    }
}
