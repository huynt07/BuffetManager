using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class BanService
    {
        // Kiểm tra dữ liệu trước khi thêm bàn
        public void Them(
            string tenBan,
            int maKV,
            int soCho,
            bool hoatDong)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Không chấp nhận tên trống
            if (string.IsNullOrWhiteSpace(tenBan))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên bàn.");
            }

            // Phải chọn khu vực
            if (maKV <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn khu vực.");
            }

            // Khớp với giới hạn đã đặt trên NumericUpDown
            if (soCho < 1 || soCho > 100)
            {
                throw new ArgumentException(
                    "Số chỗ phải từ 1 đến 100.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenBan = tenBan.Trim();

            var repository = new BanRepository();
            repository.Them(tenBan, maKV, soCho, hoatDong);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa bàn
        public void Sua(
            int maBan,
            string tenBan,
            int maKV,
            int soCho,
            bool hoatDong)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maBan <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn bàn cần sửa.");
            }

            // Không chấp nhận tên trống
            if (string.IsNullOrWhiteSpace(tenBan))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên bàn.");
            }

            if (maKV <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn khu vực.");
            }

            // Giới hạn giống khi thêm bàn
            if (soCho < 1 || soCho > 100)
            {
                throw new ArgumentException(
                    "Số chỗ phải từ 1 đến 100.");
            }

            // Bỏ khoảng trắng đầu và cuối
            tenBan = tenBan.Trim();

            // Repository kiểm tra ràng buộc và lưu thay đổi
            var repository = new BanRepository();

            repository.Sua(
                maBan,
                tenBan,
                maKV,
                soCho,
                hoatDong);
        }

        // Kiểm tra quyền và mã bàn trước khi xóa
        public void Xoa(int maBan)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã bàn phải hợp lệ
            if (maBan <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn bàn cần xóa.");
            }

            // Repository kiểm tra lịch sử liên quan trước khi xóa
            var repository = new BanRepository();
            repository.Xoa(maBan);
        }
    }
}
