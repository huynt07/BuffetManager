using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Một dòng nguyên liệu trên phiếu nhập chưa lưu
    public class ChiTietNhapDTO
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public string DonVi { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }

        // Tính thành tiền và làm tròn đến đồng
        public decimal ThanhTien
        {
            get
            {
                return Math.Round(
                    SoLuong * DonGia,
                    0,
                    MidpointRounding.AwayFromZero);
            }
        }
    }
}
