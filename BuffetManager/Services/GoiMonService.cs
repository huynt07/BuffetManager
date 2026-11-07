using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class GoiMonService
    {
        public List<ThucDonDTO> ThucDon(int id, string loai, string tim)
        {
            NghiepVuHelper.Quyen("GOI_MON");
            return new GoiMonRepository().ThucDon(id, loai, tim);
        }

        public int Gui(GoiMonDTO d)
        {
            NghiepVuHelper.Quyen("GOI_MON");
            if (d == null || d.MaLuot <= 0 || d.ChiTiet == null || d.ChiTiet.Count == 0)
                throw new ArgumentException("Chưa có món trong phiếu.");
            if (d.ChiTiet.Count > 200)
                throw new ArgumentException("Mỗi phiếu tối đa 200 dòng.");
            foreach (var x in d.ChiTiet)
                if (x == null || x.Ma <= 0 || (x.Loai != "MON" && x.Loai != "COMBO") || x.SoLuong < 1 || x.SoLuong > 1000 || x.DonGia < 0)
                    throw new ArgumentException("Dòng gọi món không hợp lệ.");
            d.GhiChu = (d.GhiChu ?? "").Trim();
            if (d.GhiChu.Length > 255)
                throw new ArgumentException("Ghi chú tối đa 255 ký tự.");
            return new GoiMonRepository().Gui(d, UserSession.MaND);
        }
    }
}
