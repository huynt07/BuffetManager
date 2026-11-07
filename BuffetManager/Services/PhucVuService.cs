using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class PhucVuService
    {
        private void Check()
        {
            NghiepVuHelper.Quyen("MO_BAN", "GOI_MON", "CHUYEN_GOP_BAN", "LAP_HOADON", "THANH_TOAN");
        }

        public List<BanPhucVuDTO> DanhSach()
        {
            Check();
            return new PhucVuRepository().DanhSach();
        }

        public List<KHUVUC> KhuVuc()
        {
            Check();
            return new PhucVuRepository().KhuVuc();
        }

        public LUOTPHUCVU Luot(int id)
        {
            Check();
            return new PhucVuRepository().Luot(id);
        }

        public string TenBan(int id)
        {
            Check();
            return new PhucVuRepository().TenBan(id);
        }

        public void HuyLuot(int id)
        {
            NghiepVuHelper.Quyen("MO_BAN");
            new PhucVuRepository().HuyLuot(id);
        }
    }
}
