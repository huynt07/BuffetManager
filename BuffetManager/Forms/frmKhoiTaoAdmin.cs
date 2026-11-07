using BuffetManager.Services;
using Guna.UI2.WinForms;
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
    public partial class frmKhoiTaoAdmin : Form
    {
        public frmKhoiTaoAdmin()
        {
            InitializeComponent();
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra mật khẩu nhập lại
            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.");
                txtNhapLaiMatKhau.Focus();
                return;
            }

            try
            {
                // Service kiểm tra dữ liệu, băm mật khẩu và lưu tài khoản
                var service = new KhoiTaoService();

                service.TaoAdminDauTien(
                    txtHoTen.Text,
                    txtTenDangNhap.Text,
                    txtMatKhau.Text);

                MessageBox.Show("Tạo tài khoản Admin thành công!");

                // Báo cho nơi mở Form biết việc khởi tạo đã thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, giữ Form mở để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể tạo tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hủy việc khởi tạo tài khoản
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            Guna2TextBox txt = sender as Guna2TextBox;

            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;

            txt.IconRight = txt.UseSystemPasswordChar
                ? Properties.Resources.eye
                : Properties.Resources.eye_off;
        }
    }
}
