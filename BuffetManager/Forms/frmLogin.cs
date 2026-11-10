using BuffetManager.Helpers;
using BuffetManager.Repositories;
using BuffetManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuffetManager.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            txtMatKhau.PasswordChar = '\0';
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.IconRight = Properties.Resources.eye;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng form đăng nhập
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa session cũ trước khi xác thực
                UserSession.DangXuat();

                // Kiểm tra tài khoản, mật khẩu và trạng thái nhân viên
                var service = new DangNhapService();

                var nguoiDung = service.DangNhap(
                    txtTenDangNhap.Text,
                    txtMatKhau.Text);

                // Chỉ lưu session khi xác thực thành công
                UserSession.DangNhap(nguoiDung);

                // Yêu cầu đổi mật khẩu lần đầu trước khi vào giao diện chính
                if (UserSession.BatBuocDoiMatKhau)
                {
                    MessageBox.Show(
                        "Bạn cần đổi mật khẩu trước khi tiếp tục.",
                        "Đổi mật khẩu lần đầu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    using (var form = new frmChangePassword())
                    {
                        if (form.ShowDialog(this) != DialogResult.OK)
                        {
                            // Hủy hoặc đóng bằng nút X thì quay lại đăng nhập
                            UserSession.DangXuat();

                            txtMatKhau.Clear();
                            txtMatKhau.Focus();
                            return;
                        }
                    }

                    // Xóa mật khẩu cũ khỏi ô nhập sau khi đổi thành công
                    txtMatKhau.Clear();
                }

                // Nạp quyền sau khi hoàn tất bước đổi mật khẩu bắt buộc
                var phanQuyenRepository = new PhanQuyenRepository();

                var cacQuyen = phanQuyenRepository.LayMaChucNang(
                    UserSession.MaVaiTro);

                UserSession.NapQuyen(cacQuyen);

                Form formChinh;

                // Chọn giao diện theo vai trò từ database
                switch (UserSession.MaVaiTro)
                {
                    case "ADMIN":
                        formChinh = new frmMain();
                        break;

                    case "PHUCVU":
                    case "BEP":
                    case "PHACHE":
                        formChinh = new frmNhanVien();
                        break;

                    default:
                        throw new InvalidOperationException(
                            "Vai trò tài khoản không hợp lệ.");
                }

                // Ẩn màn hình đăng nhập khi mở giao diện chính
                this.Hide();

                try
                {
                    using (formChinh)
                    {
                        formChinh.ShowDialog();
                    }
                }
                finally
                {
                    // Đóng giao diện chính thì quay lại đăng nhập
                    UserSession.DangXuat();
                    txtMatKhau.Clear();

                    this.Show();
                    txtTenDangNhap.Focus();
                }
            }
            catch (Exception ex)
            {
                // Không giữ session nếu đăng nhập thất bại
                UserSession.DangXuat();

                MessageBox.Show(
                    ex.Message,
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            // Đổi trạng thái ẩn/hiện mật khẩu
            txtMatKhau.UseSystemPasswordChar =
                !txtMatKhau.UseSystemPasswordChar;

            // Đổi hình con mắt
            if (txtMatKhau.UseSystemPasswordChar)
            {
                txtMatKhau.IconRight = Properties.Resources.eye;
            }
            else
            {
                txtMatKhau.IconRight = Properties.Resources.eye_off;
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAppConfig())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
