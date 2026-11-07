using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class KhoiTaoService
    {
        public void TaoAdminDauTien(
            string hoTen,
            string tenDangNhap,
            string matKhau)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new ArgumentException(
                    "Vui lòng nhập họ tên và tên đăng nhập.");
            }

            // Kiểm tra độ dài theo các cột trong database
            if (hoTen.Trim().Length > 50 ||
                tenDangNhap.Length > 20)
            {
                throw new ArgumentException(
                    "Họ tên tối đa 50 ký tự, tên đăng nhập tối đa 20 ký tự.");
            }

            // Quy định mật khẩu tối thiểu 6 ký tự
            if (string.IsNullOrWhiteSpace(matKhau) ||
                matKhau.Length < 6)
            {
                throw new ArgumentException(
                    "Mật khẩu phải có ít nhất 6 ký tự.");
            }

            // Không cho phép khoảng trắng trong tên đăng nhập và mật khẩu
            if (tenDangNhap.Any(char.IsWhiteSpace) ||
                matKhau.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException(
                    "Tên đăng nhập và mật khẩu không được chứa khoảng trắng.");
            }

            // Tạo Salt ngẫu nhiên cho tài khoản mới
            byte[] salt = PasswordHelper.CreateSalt();

            // Băm mật khẩu bằng SHA-256 kết hợp Salt
            byte[] hash = PasswordHelper.HashPassword(matKhau, salt);

            // Gọi Repository để lưu nhân viên và tài khoản
            var repository = new NguoiDungRepository();

            repository.TaoAdminDauTien(
                hoTen.Trim(),
                tenDangNhap,
                hash,
                salt);
        }
    }
}
