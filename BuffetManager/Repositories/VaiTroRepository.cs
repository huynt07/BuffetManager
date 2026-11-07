using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class VaiTroRepository
    {
        // Lấy danh sách vai trò để hiển thị trên ComboBox
        public List<VAITRO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<VAITRO>()
                         .OrderBy(vt => vt.TenVaiTro)
                         .ToList();
            }
        }
    }
}
