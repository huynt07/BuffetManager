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
    public partial class frmGoiBuffet : Form
    {
        // null nghĩa là chưa chọn gói buffet
        private int? maGoiDangChon = null;

        public frmGoiBuffet()
        {
            InitializeComponent();

            dgvGoiBuffet.AutoGenerateColumns = false;
        }

        // Hiển thị danh sách gói buffet
        private void TaiDanhSachGoi()
        {
            var repository = new GoiBuffetRepository();

            var danhSach = repository.LayDanhSach()
                .Select(goi => new
                {
                    goi.MaGoi, // Mã số nội bộ
                    MaHienThi = "BUFFET" +
                        (goi.GiaNguoiLon / 1000m).ToString("0"),
                    goi.TenGoi,
                    goi.GiaNguoiLon,
                    goi.DonGiaPhatMoiKg,
                    goi.DangBan
                })
                .ToList();

            dgvGoiBuffet.DataSource = danhSach;
        }

        private void frmGoiBuffet_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDanhSachGoi();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải gói buffet: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new GoiBuffetService();

                service.Them(
                    txtTenGoi.Text,
                    nudGiaNguoiLon.Value,
                    nudGiaPhat.Value,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm gói buffet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Gói đã được lưu thành công
            MessageBox.Show("Thêm gói buffet thành công!");
            txtTenGoi.Clear();
            txtTenGoi.Focus();

            try
            {
                // Tải lại bảng để hiển thị gói vừa thêm
                TaiDanhSachGoi();
                dgvGoiBuffet.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm gói, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvGoiBuffet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            var dong = dgvGoiBuffet.Rows[e.RowIndex];

            // Ghi nhớ mã gói và đưa thông tin lên giao diện
            maGoiDangChon = Convert.ToInt32(dong.Cells["MaGoi"].Value);
            txtTenGoi.Text = Convert.ToString(dong.Cells["TenGoi"].Value);

            nudGiaNguoiLon.Value =
                Convert.ToDecimal(dong.Cells["GiaNguoiLon"].Value);

            nudGiaPhat.Value =
                Convert.ToDecimal(dong.Cells["DonGiaPhatMoiKg"].Value);

            chkDangBan.Checked =
                Convert.ToBoolean(dong.Cells["DangBan"].Value);

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm gói
        private void LamMoi()
        {
            maGoiDangChon = null;

            txtTenGoi.Clear();
            nudGiaNguoiLon.Value = 0;
            nudGiaPhat.Value = 0;
            chkDangBan.Checked = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvGoiBuffet.ClearSelection();
            txtTenGoi.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn gói trước khi sửa
            if (!maGoiDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn gói buffet cần sửa.");
                return;
            }

            try
            {
                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new GoiBuffetService();

                service.Sua(
                    maGoiDangChon.Value,
                    txtTenGoi.Text,
                    nudGiaNguoiLon.Value,
                    nudGiaPhat.Value,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa gói buffet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật gói buffet thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu mới nhất
                TaiDanhSachGoi();
                dgvGoiBuffet.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật gói, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn gói trước khi xóa
            if (!maGoiDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn gói buffet cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa gói buffet có mã "
                    + maGoiDangChon.Value + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Service kiểm tra quyền; Repository kiểm tra dữ liệu liên quan
                var service = new GoiBuffetService();
                service.Xoa(maGoiDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa gói buffet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa gói buffet thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachGoi();
                dgvGoiBuffet.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa gói, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
