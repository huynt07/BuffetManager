using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuffetManager.Forms
{
    public partial class frmAppConfig : Form
    {
        public frmAppConfig()
        {
            InitializeComponent();
            TaiCauHinh();
        }


        private const string TenKetNoi =
            "BuffetManager.Properties.Settings.BuffetDBConnectionString";

        // 1. Đọc cấu hình hiện tại
        private void TaiCauHinh()
        {
            var item = ConfigurationManager
                .ConnectionStrings[TenKetNoi];

            if (item == null)
                return;

            var builder = new SqlConnectionStringBuilder(
                item.ConnectionString);

            txtServer.Text = builder.DataSource;
            txtDatabase.Text = builder.InitialCatalog;
        }

        // 2. Tạo chuỗi kết nối
        private string TaoChuoiKetNoi()
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();

            if (server == "" || database == "")
                throw new Exception(
                    "Vui lòng nhập đầy đủ Server và Database!");

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                IntegratedSecurity = true,
                TrustServerCertificate = true,
                ConnectTimeout = 5
            };

            return builder.ConnectionString;
        }

        // 3. Kiểm tra kết nối
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(TaoChuoiKetNoi()))
                {
                    conn.Open();
                }

                MessageBox.Show(
                    "Kết nối SQL Server thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Kết nối thất bại:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 4. Lưu cấu hình
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiKetNoi = TaoChuoiKetNoi();

                // Kiểm tra trước khi lưu
                using (var conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                }

                // Mở file cấu hình của ứng dụng đang chạy
                var config = ConfigurationManager
                    .OpenExeConfiguration(ConfigurationUserLevel.None);

                var item = config.ConnectionStrings
                    .ConnectionStrings[TenKetNoi];

                if (item == null)
                    throw new Exception(
                        "Không tìm thấy chuỗi kết nối trong App.config!");

                item.ConnectionString = chuoiKetNoi;

                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(
                    "connectionStrings");

                MessageBox.Show(
                    "Lưu cấu hình thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu cấu hình:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 5. Đóng Form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
