using BuffetManager.Forms;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuffetManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmKhoiTaoAdmin());

            try
            {
                var repository = new NguoiDungRepository();

                // Chưa có tài khoản thì yêu cầu khởi tạo Admin
                if (!repository.DaCoTaiKhoan())
                {
                    using (var form = new frmKhoiTaoAdmin())
                    {
                        // Nếu người dùng thoát hoặc đóng Form thì dừng ứng dụng
                        if (form.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }
                }

                // Đã có tài khoản thì mở màn hình đăng nhập
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể khởi động ứng dụng: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
