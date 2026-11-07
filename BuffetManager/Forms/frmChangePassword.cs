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
using static System.Net.Mime.MediaTypeNames;

namespace BuffetManager.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin và lưu mật khẩu mới
                var service = new DoiMatKhauService();

                service.DoiMatKhau(
                    txtMatKhauCu.Text,
                    txtMatKhauMoi.Text,
                    txtXacNhanMatKhau.Text);

                MessageBox.Show(
                    "Đổi mật khẩu thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Báo thành công cho Form đã mở cửa sổ này
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Có lỗi thì giữ Form mở để người dùng sửa
                MessageBox.Show(
                    ex.Message,
                    "Không thể đổi mật khẩu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Báo người dùng đã hủy việc đổi mật khẩu
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
