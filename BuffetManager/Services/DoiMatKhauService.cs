using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class DoiMatKhauService
    {
        public void DoiMatKhau(
            string matKhauCu,
            string matKhauMoi,
            string xacNhanMatKhau)
        {
            // Chỉ người đã đăng nhập mới được đổi mật khẩu
            if (!UserSession.DaDangNhap)
            {
                throw new InvalidOperationException(
                    "Vui lòng đăng nhập trước.");
            }

            // Kiểm tra mật khẩu mới
            if (string.IsNullOrWhiteSpace(matKhauMoi) ||
                matKhauMoi.Length < 6)
            {
                throw new ArgumentException(
                    "Mật khẩu mới phải có ít nhất 6 ký tự.");
            }

            if (matKhauMoi.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException(
                    "Mật khẩu mới không được chứa khoảng trắng.");
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                throw new ArgumentException(
                    "Mật khẩu nhập lại không khớp.");
            }

            // Xác thực lại mật khẩu hiện tại và trạng thái tài khoản
            var dangNhapService = new DangNhapService();

            var nguoiDung = dangNhapService.DangNhap(
                UserSession.TenDangNhap,
                matKhauCu);

            // Đảm bảo đang cập nhật đúng tài khoản trong session
            if (nguoiDung.MaND != UserSession.MaND)
            {
                throw new InvalidOperationException(
                    "Thông tin tài khoản đã thay đổi. Vui lòng đăng nhập lại.");
            }

            if (matKhauMoi == matKhauCu)
            {
                throw new ArgumentException(
                    "Mật khẩu mới phải khác mật khẩu hiện tại.");
            }

            // Mỗi lần đổi mật khẩu đều tạo Salt mới
            byte[] saltMoi = PasswordHelper.CreateSalt();
            byte[] hashMoi = PasswordHelper.HashPassword(
                matKhauMoi, saltMoi);

            var repository = new NguoiDungRepository();
            repository.CapNhatMatKhau(
                nguoiDung.MaND, hashMoi, saltMoi);

            // Đồng bộ session sau khi lưu database thành công
            nguoiDung.BatBuocDoiMatKhau = false;
            UserSession.DangNhap(nguoiDung);
        }
    }
}
