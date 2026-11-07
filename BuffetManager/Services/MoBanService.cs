using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class MoBanService
    {
        public int MoBan(MoBanDTO d)
        {
            NghiepVuHelper.Quyen("MO_BAN");
            if (d == null || d.MaBan <= 0)
                throw new ArgumentException("Vui lòng chọn bàn.");
            if (d.HinhThuc != "BUFFET" && d.HinhThuc != "COMBO" && d.HinhThuc != "GOIMON")
                throw new ArgumentException("Chọn hình thức dùng bữa.");
            if (d.MaDatBan.HasValue && d.MaDatBan <= 0)
                throw new ArgumentException("Lượt đặt không hợp lệ.");
            if (d.HinhThuc == "BUFFET")
            {
                if (!d.MaGoi.HasValue || d.MaGoi <= 0)
                    throw new ArgumentException("Chọn gói buffet.");
                if (d.SoKhachDuoi1m < 0 || d.SoKhachDuoi1m > 100 || d.SoKhachTu1mDenDuoi1m3 < 0 || d.SoKhachTu1mDenDuoi1m3 > 100 || d.SoKhachTu1m3 < 0 || d.SoKhachTu1m3 > 100 || d.TongKhachBuffet == 0)
                    throw new ArgumentException("Nhập số khách buffet hợp lệ (ít nhất 1 khách).");
            }
            else
            {
                d.MaGoi = null;
                d.SoKhachDuoi1m = 0;
                d.SoKhachTu1mDenDuoi1m3 = 0;
                d.SoKhachTu1m3 = 0;
            }

            return new MoBanRepository().MoBan(d, UserSession.MaND);
        }
    }
}
