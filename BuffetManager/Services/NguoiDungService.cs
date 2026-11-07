using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class NguoiDungService
    {
        public void ThemTaiKhoan(
            string hoTen,
            string tenDangNhap,
            string matKhau,
            string maVaiTro,
            bool hoatDong)
        {
            // Kiểm tra quyền ngay tại lớp xử lý
            if (!UserSession.CoQuyen("QUANLY_TAIKHOAN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý tài khoản.");
            }

            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(maVaiTro))
            {
                throw new ArgumentException(
                    "Vui lòng nhập họ tên, tên đăng nhập và chọn vai trò.");
            }

            // Giới hạn theo quy định đã chọn trên giao diện
            if (hoTen.Trim().Length > 50 ||
                tenDangNhap.Length > 20)
            {
                throw new ArgumentException(
                    "Họ tên tối đa 50 ký tự, tên đăng nhập tối đa 20 ký tự.");
            }

            // Mật khẩu tối thiểu 6 ký tự
            if (string.IsNullOrWhiteSpace(matKhau) ||
                matKhau.Length < 6)
            {
                throw new ArgumentException(
                    "Mật khẩu phải có ít nhất 6 ký tự.");
            }

            // Họ tên được có dấu cách; tài khoản và mật khẩu thì không
            if (tenDangNhap.Any(char.IsWhiteSpace) ||
                matKhau.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException(
                    "Tên đăng nhập và mật khẩu không được chứa khoảng trắng.");
            }

            // Tạo Salt riêng cho tài khoản mới
            byte[] salt = PasswordHelper.CreateSalt();
            byte[] hash = PasswordHelper.HashPassword(matKhau, salt);

            // Lưu nhân viên và tài khoản
            var repository = new NguoiDungRepository();

            repository.ThemTaiKhoan(
                hoTen.Trim(),
                tenDangNhap,
                maVaiTro,
                hash,
                salt,
                hoatDong);
        }

        // Kiểm tra dữ liệu trước khi cập nhật tài khoản
        public void CapNhatTaiKhoan(
            int maND,
            string hoTen,
            string maVaiTro,
            bool hoatDong)
        {
            // Kiểm tra quyền quản lý tài khoản
            if (!UserSession.CoQuyen("QUANLY_TAIKHOAN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý tài khoản.");
            }

            if (maND <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn tài khoản cần cập nhật.");
            }

            // Họ tên được chứa dấu cách
            if (string.IsNullOrWhiteSpace(hoTen) ||
                hoTen.Trim().Length > 50)
            {
                throw new ArgumentException(
                    "Họ tên không được để trống và tối đa 50 ký tự.");
            }

            if (string.IsNullOrWhiteSpace(maVaiTro))
            {
                throw new ArgumentException(
                    "Vui lòng chọn vai trò.");
            }

            // Bảo vệ tài khoản đang dùng
            if (maND == UserSession.MaND)
            {
                if (!hoatDong)
                {
                    throw new InvalidOperationException(
                        "Bạn không thể tự khóa tài khoản đang đăng nhập.");
                }

                if (maVaiTro != UserSession.MaVaiTro)
                {
                    throw new InvalidOperationException(
                        "Bạn không thể tự đổi vai trò của tài khoản đang đăng nhập.");
                }
            }

            // Gọi Repository để lưu thay đổi
            var repository = new NguoiDungRepository();

            repository.CapNhatTaiKhoan(
                maND,
                hoTen.Trim(),
                maVaiTro,
                hoatDong);
        }

        public void XoaTaiKhoan(int maND)
        {
            if (!UserSession.CoQuyen("QUANLY_TAIKHOAN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý tài khoản.");
            }

            if (maND <= 0)
            {
                throw new ArgumentException("Vui lòng chọn tài khoản cần xóa.");
            }

            // Không cho tự xóa chính mình
            if (maND == UserSession.MaND)
            {
                throw new InvalidOperationException(
                    "Bạn không thể xóa tài khoản đang đăng nhập.");
            }

            new NguoiDungRepository().XoaTaiKhoan(maND);
        }
    }
}
