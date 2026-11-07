using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class GoiBuffetMonService
    {
        // Kiểm tra quyền và dữ liệu trước khi lưu
        public void LuuDanhSachMon(int maGoi, List<int> cacMaMon)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maGoi <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn gói buffet.");
            }

            if (cacMaMon == null)
            {
                throw new ArgumentException(
                    "Danh sách món không hợp lệ.");
            }

            // Các mã món phải là số dương
            if (cacMaMon.Any(ma => ma <= 0))
            {
                throw new ArgumentException(
                    "Có mã món không hợp lệ.");
            }

            // Repository kiểm tra ràng buộc và lưu bằng transaction
            var repository = new GoiBuffetMonRepository();
            repository.LuuDanhSachMon(maGoi, cacMaMon);
        }
    }
}
