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
                bool daCoTaiKhoan;

                while (true)
                {
                    try
                    {
                        var repository = new NguoiDungRepository();
                        daCoTaiKhoan = repository.DaCoTaiKhoan();
                        break;
                    }
                    catch (Exception ex)
                    {
                        var ketQua = MessageBox.Show(
                            "Không kết nối được database:\n" +
                            ex.Message +
                            "\n\nBạn có muốn cấu hình lại không?",
                            "Lỗi kết nối",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (ketQua != DialogResult.Yes)
                            return;

                        using (var frm = new frmAppConfig())
                        {
                            if (frm.ShowDialog() != DialogResult.OK)
                                return;
                        }
                    }
                }

                // Chưa có tài khoản thì khởi tạo Admin
                if (!daCoTaiKhoan)
                {
                    using (var form = new frmKhoiTaoAdmin())
                    {
                        if (form.ShowDialog() != DialogResult.OK)
                            return;
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
