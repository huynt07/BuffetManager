using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class HoaDonService
    {
        public List<HoaDonDTO> DanhSach(DateTime tu, DateTime den, string mode, int page, int size, out int count, out decimal total)
        {
            NghiepVuHelper.Quyen("XEM_BAOCAO");
            if (tu.Date > den.Date || den.Date == DateTime.MaxValue.Date)
                throw new ArgumentException("Khoảng ngày không hợp lệ.");
            if (page < 1 || size < 1 || size > 100)
                throw new ArgumentException("Phân trang không hợp lệ.");
            return new HoaDonRepository().DanhSach(tu.Date, den.Date.AddDays(1), mode, page, size, out count, out total);
        }

        public List<ChiTietHoaDonDTO> ChiTiet(int id)
        {
            NghiepVuHelper.Quyen("XEM_BAOCAO");
            return new HoaDonRepository().ChiTietDaLuu(id);
        }
    }
}
