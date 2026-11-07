using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class XuLyPhieuService
    {
        private void CheckDept(string dept)
        {
            if (dept != "BEP" && dept != "PHACHE")
                throw new ArgumentException("Bộ phận không hợp lệ.");
            NghiepVuHelper.Quyen(dept == "BEP" ? "XULY_MON_BEP" : "XULY_DO_UONG", "GOI_MON");
        }

        public List<ChiTietPhieuDTO> DanhSach(string dept, string status)
        {
            CheckDept(dept);
            return new XuLyPhieuRepository().DanhSach(dept, status);
        }

        public void CapNhat(int id, string dept, string action)
        {
            CheckDept(dept);
            if (action == "DANG_LAM" || action == "DA_XONG")
                NghiepVuHelper.Quyen(dept == "BEP" ? "XULY_MON_BEP" : "XULY_DO_UONG");
            else if (action == "DA_PHUC_VU")
                NghiepVuHelper.Quyen("GOI_MON");
            else if (action != "HUY")
                throw new ArgumentException("Thao tác không hợp lệ.");
            new XuLyPhieuRepository().CapNhat(id, dept, action, UserSession.MaND, UserSession.CoQuyen("GOI_MON"));
        }
    }
}
