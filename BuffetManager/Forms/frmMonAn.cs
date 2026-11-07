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
    public partial class frmMonAn : Form
    {
        // null nghĩa là chưa chọn món
        private int? maMonDangChon = null;

        public frmMonAn()
        {
            InitializeComponent();

            dgvMonAn.AutoGenerateColumns = false;
        }

        // Hiển thị tên danh mục, giữ giá trị là mã danh mục
        private void TaiDanhMuc()
        {
            var repository = new DanhMucMonRepository();

            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";
            cboDanhMuc.DataSource = repository.LayDanhSach();

            // Yêu cầu người dùng tự chọn danh mục
            cboDanhMuc.SelectedIndex = -1;
        }

        // Hiển thị danh sách món ăn
        private void TaiDanhSachMon()
        {
            var repository = new MonAnRepository();

            dgvMonAn.DataSource = repository.LayDanhSach();
        }

        private void frmMonAn_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDanhMuc();
                TaiDanhSachMon();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu món ăn: " + ex.Message,
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
            // Phải chọn danh mục trước khi thêm
            if (cboDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                cboDanhMuc.Focus();
                return;
            }

            try
            {
                int maDM = Convert.ToInt32(cboDanhMuc.SelectedValue);

                // Value của NumericUpDown đã có kiểu decimal
                decimal giaLe = nudGiaLe.Value;

                var service = new MonAnService();

                service.Them(
                    txtTenMon.Text,
                    maDM,
                    txtDonVi.Text,
                    giaLe,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm món",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Món đã được lưu thành công
            MessageBox.Show("Thêm món thành công!");
            txtTenMon.Clear();
            txtTenMon.Focus();

            try
            {
                // Tải lại bảng để hiển thị món vừa thêm
                TaiDanhSachMon();
                dgvMonAn.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm món, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            // Lấy thông tin món của dòng được chọn
            var mon = dgvMonAn.Rows[e.RowIndex].DataBoundItem as MonAnDTO;

            if (mon == null)
            {
                return;
            }

            // Ghi nhớ mã món và điền thông tin lên giao diện
            maMonDangChon = mon.MaMon;
            txtTenMon.Text = mon.TenMon;
            cboDanhMuc.SelectedValue = mon.MaDM;
            txtDonVi.Text = mon.DonVi;
            nudGiaLe.Value = mon.GiaLe;
            chkDangBan.Checked = mon.DangBan;

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm món
        private void LamMoi()
        {
            maMonDangChon = null;

            txtTenMon.Clear();
            txtDonVi.Clear();
            cboDanhMuc.SelectedIndex = -1;
            nudGiaLe.Value = 0;
            chkDangBan.Checked = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvMonAn.ClearSelection();
            txtTenMon.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn món trước khi sửa
            if (!maMonDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa.");
                return;
            }

            // Phải chọn danh mục
            if (cboDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                cboDanhMuc.Focus();
                return;
            }

            try
            {
                int maDM = Convert.ToInt32(cboDanhMuc.SelectedValue);

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new MonAnService();

                service.Sua(
                    maMonDangChon.Value,
                    txtTenMon.Text,
                    maDM,
                    txtDonVi.Text,
                    nudGiaLe.Value,
                    chkDangBan.Checked);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa món",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật món thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu sau khi sửa
                TaiDanhSachMon();
                dgvMonAn.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật món, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn món trước khi xóa
            if (!maMonDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa món có mã "
                    + maMonDangChon.Value + "?",
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
                var service = new MonAnService();
                service.Xoa(maMonDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa món",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa món thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachMon();
                dgvMonAn.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa món, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
