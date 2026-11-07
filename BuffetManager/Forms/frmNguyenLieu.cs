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
    public partial class frmNguyenLieu : Form
    {
        // null nghĩa là chưa chọn nguyên liệu
        private int? maNLDangChon = null;

        public frmNguyenLieu()
        {
            InitializeComponent();

            dgvNguyenLieu.AutoGenerateColumns = false;
        }

        // Hiển thị tên bộ phận, giữ mã để lưu database
        private void TaiBoPhan()
        {
            var danhSach = new[]
            {
        new { Ma = "BEP", Ten = "Bếp" },
        new { Ma = "PHACHE", Ten = "Pha chế" }
    };

            cboBoPhan.DisplayMember = "Ten";
            cboBoPhan.ValueMember = "Ma";
            cboBoPhan.DataSource = danhSach;
            cboBoPhan.SelectedIndex = -1;
        }

        // Hiển thị nguyên liệu và mức tồn kho
        private void TaiDanhSachNguyenLieu()
        {
            var repository = new NguyenLieuRepository();

            dgvNguyenLieu.DataSource = repository.LayDanhSach();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            try
            {
                TaiBoPhan();
                TaiDanhSachNguyenLieu();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải nguyên liệu: " + ex.Message,
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
                // Lấy mã bộ phận đang chọn
                string boPhan = cboBoPhan.SelectedValue as string;

                var service = new NguyenLieuService();

                service.Them(
                    txtTenNguyenLieu.Text,
                    txtDonVi.Text,
                    boPhan,
                    nudMucCanhBao.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm nguyên liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Nguyên liệu đã được lưu thành công
            MessageBox.Show("Thêm nguyên liệu thành công!");
            txtTenNguyenLieu.Clear();
            txtTenNguyenLieu.Focus();

            try
            {
                // Hiển thị lại danh sách sau khi thêm
                TaiDanhSachNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm nguyên liệu, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            // Lấy thông tin nguyên liệu của dòng được chọn
            var nguyenLieu = dgvNguyenLieu.Rows[e.RowIndex]
                                         .DataBoundItem as NguyenLieuDTO;

            if (nguyenLieu == null)
            {
                return;
            }

            // Ghi nhớ mã và đưa thông tin lên giao diện
            maNLDangChon = nguyenLieu.MaNL;
            txtTenNguyenLieu.Text = nguyenLieu.TenNL;
            txtDonVi.Text = nguyenLieu.DonVi;
            cboBoPhan.SelectedValue = nguyenLieu.BoPhan;
            nudMucCanhBao.Value = nguyenLieu.MucCanhBao;

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm nguyên liệu
        private void LamMoi()
        {
            maNLDangChon = null;

            txtTenNguyenLieu.Clear();
            txtDonVi.Clear();
            cboBoPhan.SelectedIndex = -1;
            nudMucCanhBao.Value = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvNguyenLieu.ClearSelection();
            txtTenNguyenLieu.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn nguyên liệu trước khi sửa
            if (!maNLDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa.");
                return;
            }

            try
            {
                string boPhan = cboBoPhan.SelectedValue as string;

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new NguyenLieuService();

                service.Sua(
                    maNLDangChon.Value,
                    txtTenNguyenLieu.Text,
                    txtDonVi.Text,
                    boPhan,
                    nudMucCanhBao.Value);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa nguyên liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật nguyên liệu thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu mới nhất
                TaiDanhSachNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật nguyên liệu, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn nguyên liệu trước khi xóa
            if (!maNLDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa nguyên liệu có mã "
                    + maNLDangChon.Value + "?",
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
                var service = new NguyenLieuService();
                service.Xoa(maNLDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa nguyên liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa nguyên liệu thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachNguyenLieu();
                dgvNguyenLieu.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa nguyên liệu, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
