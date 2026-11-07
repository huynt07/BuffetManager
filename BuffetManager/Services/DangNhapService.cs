using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class DangNhapService
    {
        public NGUOIDUNG DangNhap(string tenDangNhap, string matKhau)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên đăng nhập và mật khẩu.");
            }

            // Không cho phép khoảng trắng
            if (tenDangNhap.Any(char.IsWhiteSpace) ||
                matKhau.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException(
                    "Tên đăng nhập và mật khẩu không được chứa khoảng trắng.");
            }

            // Tìm tài khoản trong database
            var repository = new NguoiDungRepository();
            var nguoiDung = repository.TimTheoTenDangNhap(tenDangNhap);

            if (nguoiDung == null)
            {
                throw new ArgumentException(
                    "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            // Dùng Salt đã lưu để kiểm tra mật khẩu
            bool dungMatKhau = PasswordHelper.VerifyPassword(
                matKhau,
                nguoiDung.Salt.ToArray(),
                nguoiDung.MatKhauHash.ToArray());

            if (!dungMatKhau)
            {
                throw new ArgumentException(
                    "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            // Tài khoản bị khóa thì không được đăng nhập
            if (!nguoiDung.HoatDong)
            {
                throw new InvalidOperationException(
                    "Tài khoản đã bị khóa.");
            }

            // Nhân viên đã nghỉ việc thì không được đăng nhập
            if (!repository.NhanVienConLamViec(nguoiDung.MaNV))
            {
                throw new InvalidOperationException(
                    "Nhân viên đã nghỉ việc, không thể đăng nhập.");
            }

            return nguoiDung;
        }
    }
}
