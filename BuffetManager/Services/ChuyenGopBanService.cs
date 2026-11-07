using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class ChuyenGopBanService
    {
        public void ThucHien(ChuyenGopBanDTO d)
        {
            NghiepVuHelper.Quyen("CHUYEN_GOP_BAN");
            if (d == null || d.MaBanNguon <= 0 || d.MaBanDich <= 0 || d.MaLuotNguon <= 0 || d.MaBanNguon == d.MaBanDich)
                throw new ArgumentException("Chọn hai bàn khác nhau.");
            if (d.ThaoTac != "CHUYEN" && d.ThaoTac != "GOP")
                throw new ArgumentException("Chọn thao tác hợp lệ.");
            new ChuyenGopBanRepository().ThucHien(d);
        }
    }
}
