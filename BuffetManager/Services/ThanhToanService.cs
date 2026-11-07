using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class ThanhToanService
    {
        public List<ChiTietHoaDonDTO> DuTinh(int id, decimal kg)
        {
            NghiepVuHelper.Quyen("LAP_HOADON", "THANH_TOAN");
            KiemTraKg(kg);
            return new HoaDonRepository().DuTinh(id, kg);
        }

        private void KiemTraKg(decimal kg)
        {
            if (kg < 0 || kg > 1000 || decimal.Round(kg, 3) != kg)
                throw new ArgumentException("Khối lượng thừa từ 0 đến 1000 kg, tối đa 3 số lẻ.");
        }

        public int ThanhToan(ThanhToanDTO d)
        {
            NghiepVuHelper.Quyen("THANH_TOAN");
            if (d == null || d.MaLuot <= 0)
                throw new ArgumentException("Lượt phục vụ không hợp lệ.");
            KiemTraKg(d.KhoiLuongThua);
            if (d.PhuongThuc != "TIENMAT" && d.PhuongThuc != "CHUYENKHOAN")
                throw new ArgumentException("Chọn phương thức thanh toán.");
            if (d.PhuongThuc == "CHUYENKHOAN" && !d.DaNhanChuyenKhoan)
                throw new ArgumentException("Phải xác nhận đã nhận tiền chuyển khoản.");
            if (d.TienKhachDua < 0 || d.TienKhachDua > 1000000000m || decimal.Round(d.TienKhachDua, 2) != d.TienKhachDua)
                throw new ArgumentException("Tiền khách đưa không hợp lệ.");
            return new HoaDonRepository().ThanhToan(d, UserSession.MaND);
        }
    }
}
