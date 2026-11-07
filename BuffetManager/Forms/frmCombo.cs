using BuffetManager.Models;
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
    public partial class frmCombo : Form
    {
        // null nghĩa là chưa chọn combo
        private int? maComboDangChon = null;

        public frmCombo()
        {
            InitializeComponent();

            dgvCombo.AutoGenerateColumns = false;
        }

        // Hiển thị danh sách combo
        private void TaiDanhSachCombo()
        {
            var repository = new ComboRepository();

            var danhSach = repository.LayDanhSach()
                .Select(cb => new
                {
                    cb.MaCombo, // Mã số nội bộ
                    MaHienThi = "COMBO" +
                        (cb.GiaCombo / 1000m).ToString("0"),
                    cb.TenCombo,
                    cb.SoNguoiGoiY,
                    cb.GiaCombo,
                    cb.DangBan
                })
                .ToList();

            dgvCombo.DataSource = danhSach;
        }

        private void frmCombo_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDanhSachCombo();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách combo: " + ex.Message,
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
                // Lấy số người gợi ý từ giao diện
                int soNguoiGoiY = Convert.ToInt32(nudSoNguoi.Value);

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new ComboService();

                service.Them(
                    txtTenCombo.Text,
                    soNguoiGoiY,
                    nudGiaCombo.Value,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm combo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Combo đã được lưu thành công
            MessageBox.Show("Thêm combo thành công!");
            txtTenCombo.Clear();
            txtTenCombo.Focus();

            try
            {
                // Tải lại bảng để hiển thị combo vừa thêm
                TaiDanhSachCombo();
                dgvCombo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm combo, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvCombo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            var dong = dgvCombo.Rows[e.RowIndex];

            // Ghi nhớ mã combo và điền thông tin lên giao diện
            maComboDangChon =
                Convert.ToInt32(dong.Cells["MaCombo"].Value);

            txtTenCombo.Text =
                Convert.ToString(dong.Cells["TenCombo"].Value);

            nudSoNguoi.Value =
                Convert.ToDecimal(dong.Cells["SoNguoiGoiY"].Value);

            nudGiaCombo.Value =
                Convert.ToDecimal(dong.Cells["GiaCombo"].Value);

            chkDangBan.Checked =
                Convert.ToBoolean(dong.Cells["DangBan"].Value);

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm combo
        private void LamMoi()
        {
            maComboDangChon = null;

            txtTenCombo.Clear();
            nudSoNguoi.Value = 2;
            nudGiaCombo.Value = 0;
            chkDangBan.Checked = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvCombo.ClearSelection();
            txtTenCombo.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn combo trước khi sửa
            if (!maComboDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn combo cần sửa.");
                return;
            }

            try
            {
                int soNguoiGoiY = Convert.ToInt32(nudSoNguoi.Value);

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new ComboService();

                service.Sua(
                    maComboDangChon.Value,
                    txtTenCombo.Text,
                    soNguoiGoiY,
                    nudGiaCombo.Value,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa combo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật combo thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu mới nhất
                TaiDanhSachCombo();
                dgvCombo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật combo, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn combo trước khi xóa
            if (!maComboDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn combo cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa combo có mã "
                    + maComboDangChon.Value + "?",
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
                var service = new ComboService();
                service.Xoa(maComboDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa combo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa combo thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachCombo();
                dgvCombo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa combo, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
