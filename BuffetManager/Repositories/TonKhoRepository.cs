using System;
using System.Collections.Generic;
using System.Linq;
using BuffetManager.Models;
using BuffetManager.Helpers;

namespace BuffetManager.Repositories
{
    public class TonKhoRepository
    {
        public List<NguyenLieuDTO> DanhSach(string boPhan, string tim, bool canhBao)
        {
            using (var db = DbFactory.Create())
            {
                var q = db.NGUYENLIEUs.Where(x => x.BoPhan == boPhan && x.TenNL.Contains(tim ?? ""));
                if (canhBao)
                    q = q.Where(x => x.TonKho <= x.MucCanhBao);
                return q.OrderBy(x => x.TenNL).Select(x => new NguyenLieuDTO { MaNL = x.MaNL, TenNL = x.TenNL, DonVi = x.DonVi, BoPhan = x.BoPhan, TonKho = x.TonKho, MucCanhBao = x.MucCanhBao }).ToList();
            }
        }
    }
}
