using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class DanhMucMonService
    {
        // Kiểm tra dữ liệu trước khi thêm danh mục món
        public void Them(string tenDM, string boPhan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Tên không được rỗng hoặc chỉ chứa khoảng trắng
            if (string.IsNullOrWhiteSpace(tenDM))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên danh mục.");
            }

            // Chỉ chấp nhận đúng hai mã bộ phận
            if (boPhan != "BEP" && boPhan != "PHACHE")
            {
                throw new ArgumentException(
                    "Vui lòng chọn bộ phận Bếp hoặc Pha chế.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenDM = tenDM.Trim();

            // Repository kiểm tra trùng tên và lưu dữ liệu
            var repository = new DanhMucMonRepository();
            repository.Them(tenDM, boPhan);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa danh mục món
        public void Sua(int maDM, string tenDM, string boPhan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maDM <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn danh mục cần sửa.");
            }

            // Không chấp nhận tên rỗng hoặc chỉ chứa khoảng trắng
            if (string.IsNullOrWhiteSpace(tenDM))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên danh mục.");
            }

            // Chỉ chấp nhận hai mã bộ phận hợp lệ
            if (boPhan != "BEP" && boPhan != "PHACHE")
            {
                throw new ArgumentException(
                    "Vui lòng chọn bộ phận Bếp hoặc Pha chế.");
            }

            // Bỏ khoảng trắng ở đầu và cuối tên
            tenDM = tenDM.Trim();

            // Repository kiểm tra ràng buộc và lưu thay đổi
            var repository = new DanhMucMonRepository();
            repository.Sua(maDM, tenDM, boPhan);
        }

        // Kiểm tra quyền và mã danh mục trước khi xóa
        public void Xoa(int maDM)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã danh mục phải hợp lệ
            if (maDM <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn danh mục cần xóa.");
            }

            // Repository kiểm tra danh mục tồn tại và chưa có món
            var repository = new DanhMucMonRepository();
            repository.Xoa(maDM);
        }
    }
}
