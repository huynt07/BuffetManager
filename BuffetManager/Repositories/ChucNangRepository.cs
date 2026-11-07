using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class ChucNangRepository
    {
        // Lấy các chức năng theo thứ tự mã
        public List<CHUCNANG> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<CHUCNANG>()
                         .OrderBy(cn => cn.MaChucNang)
                         .ToList();
            }
        }
    }
}
