using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class KhuVucService
    {
        // Kiểm tra dữ liệu trước khi thêm khu vực
        public void Them(string tenKV)
        {
            // Kiểm tra quyền tại lớp xử lý
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Không chấp nhận tên rỗng hoặc chỉ chứa khoảng trắng
            if (string.IsNullOrWhiteSpace(tenKV))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên khu vực.");
            }

            // Bỏ khoảng trắng thừa ở đầu và cuối
            tenKV = tenKV.Trim();

            var repository = new KhuVucRepository();
            repository.Them(tenKV);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa khu vực
        public void Sua(int maKV, string tenKV)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã khu vực phải hợp lệ
            if (maKV <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn khu vực cần sửa.");
            }

            // Tên không được rỗng hoặc chỉ chứa khoảng trắng
            if (string.IsNullOrWhiteSpace(tenKV))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên khu vực.");
            }

            // Bỏ khoảng trắng ở đầu và cuối tên
            tenKV = tenKV.Trim();

            // Repository kiểm tra tồn tại, trùng tên và lưu thay đổi
            var repository = new KhuVucRepository();
            repository.Sua(maKV, tenKV);
        }

        // Kiểm tra quyền và mã khu vực trước khi xóa
        public void Xoa(int maKV)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã khu vực phải hợp lệ
            if (maKV <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn khu vực cần xóa.");
            }

            // Repository kiểm tra khu vực tồn tại và chưa có bàn
            var repository = new KhuVucRepository();
            repository.Xoa(maKV);
        }
    }
}
