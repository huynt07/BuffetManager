using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Helpers
{
    public static class UserSession
    {
        // Thông tin tài khoản đang đăng nhập
        public static int MaND { get; private set; }
        public static int MaNV { get; private set; }
        public static string TenDangNhap { get; private set; }
        public static string MaVaiTro { get; private set; }
        public static bool BatBuocDoiMatKhau { get; private set; }

        // MaND được SQL Server cấp từ 1 trở lên
        public static bool DaDangNhap => MaND > 0;

        // Lưu thông tin sau khi xác thực thành công
        public static void DangNhap(NGUOIDUNG nguoiDung)
        {
            MaND = nguoiDung.MaND;
            MaNV = nguoiDung.MaNV;
            TenDangNhap = nguoiDung.TenDangNhap;
            MaVaiTro = nguoiDung.MaVaiTro;
            BatBuocDoiMatKhau = nguoiDung.BatBuocDoiMatKhau;
        }

        // Xóa thông tin khi đăng xuất
        public static void DangXuat()
        {
            MaND = 0;
            MaNV = 0;
            TenDangNhap = null;
            MaVaiTro = null;
            BatBuocDoiMatKhau = false;
            // Xóa quyền khi kết thúc phiên đăng nhập
            danhSachQuyen.Clear();
        }

        // Lưu mã chức năng được phép sử dụng
        private static HashSet<string> danhSachQuyen = new HashSet<string>();

        // Nạp quyền lấy từ database
        public static void NapQuyen(IEnumerable<string> cacQuyen)
        {
            danhSachQuyen = new HashSet<string>(cacQuyen);
        }

        // Chỉ cho phép khi đã đăng nhập và hoàn tất đổi mật khẩu bắt buộc
        public static bool CoQuyen(string maCode)
        {
            return DaDangNhap
                && !BatBuocDoiMatKhau
                && danhSachQuyen.Contains(maCode);
        }

    }
}
