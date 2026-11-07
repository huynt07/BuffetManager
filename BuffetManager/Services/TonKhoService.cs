using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;

namespace BuffetManager.Services
{
    public class TonKhoService
    {
        public List<NguyenLieuDTO> DanhSach(string dept, string tim, bool canhBao)
        {
            if (dept != "BEP" && dept != "PHACHE")
                throw new ArgumentException("Bộ phận không hợp lệ.");
            NghiepVuHelper.Quyen(dept == "BEP" ? "XEM_KHO_BEP" : "XEM_KHO_PHACHE", "QUANLY_KHO");
            return new TonKhoRepository().DanhSach(dept, (tim ?? "").Trim(), canhBao);
        }
    }
}
