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
    public partial class frmUserManagement : Form
    {
        // Ghi nhớ tài khoản đang được chọn; null là chưa chọn
        private int? maNDDangChon = null;
        public frmUserManagement()
        {
            InitializeComponent();

            // Không tự động sinh thêm cột
            dgvTaiKhoan.AutoGenerateColumns = false;
        }
        // Hiển thị tên vai trò nhưng lưu giá trị là mã vai trò
        private void TaiVaiTro()
        {
            var repository = new VaiTroRepository();

            cboVaiTro.DisplayMember = "TenVaiTro";
            cboVaiTro.ValueMember = "MaVaiTro";
            cboVaiTro.DataSource = repository.LayDanhSach();

            // Mặc định chọn vai trò Phục vụ
            cboVaiTro.SelectedValue = "PHUCVU";
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                // Nạp vai trò khi Form được mở
                TaiVaiTro();
                TaiDanhSachTaiKhoan();
                // Thiết lập trạng thái ban đầu của Form
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Đóng cửa sổ để quay về dashboard
            this.Close();
        }
        // Tải danh sách tài khoản lên bảng
        private void TaiDanhSachTaiKhoan()
        {
            var repository = new NguoiDungRepository();

            dgvTaiKhoan.DataSource = repository.LayDanhSach();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm vào tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            // Lấy đối tượng tài khoản gắn với dòng vừa chọn
            var taiKhoan = dgvTaiKhoan.Rows[e.RowIndex]
                                      .DataBoundItem as TaiKhoanDTO;

            if (taiKhoan == null)
            {
                return;
            }

            // Lưu mã để dùng khi cập nhật
            maNDDangChon = taiKhoan.MaND;

            // Đưa thông tin lên các control
            txtHoTen.Text = taiKhoan.HoTen;
            txtTenDangNhap.Text = taiKhoan.TenDangNhap;
            cboVaiTro.SelectedValue = taiKhoan.MaVaiTro;
            chkHoatDong.Checked = taiKhoan.HoatDong;

            // Mật khẩu chỉ dùng khi tạo tài khoản mới
            txtMatKhau.Clear();
            txtMatKhau.Enabled = false;

            // Không đổi tên đăng nhập của tài khoản đã tạo
            txtTenDangNhap.ReadOnly = true;

            // Chuyển sang trạng thái chỉnh sửa
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm tài khoản
        private void LamMoi()
        {
            maNDDangChon = null;

            // Xóa nội dung các ô nhập
            txtHoTen.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            // Cho phép nhập tài khoản mới
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.Enabled = true;

            // Giá trị mặc định
            cboVaiTro.SelectedValue = "PHUCVU";
            chkHoatDong.Checked = true;

            // Chuyển trạng thái các nút
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;

            // Bỏ chọn dòng trong bảng
            dgvTaiKhoan.ClearSelection();

            txtHoTen.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Bỏ lựa chọn hiện tại để nhập tài khoản mới
            LamMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chỉ thêm khi đang ở trạng thái tạo mới
            if (maNDDangChon.HasValue)
            {
                MessageBox.Show("Hãy nhấn Làm mới trước khi thêm tài khoản.");
                return;
            }

            try
            {
                // Lấy mã vai trò đang chọn
                string maVaiTro = cboVaiTro.SelectedValue as string;

                var service = new NguoiDungService();

                service.ThemTaiKhoan(
                    txtHoTen.Text,
                    txtTenDangNhap.Text,
                    txtMatKhau.Text,
                    maVaiTro,
                    chkHoatDong.Checked);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng sửa khi thêm thất bại
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Đến đây tài khoản đã được lưu thành công
            MessageBox.Show("Thêm tài khoản thành công!");
            LamMoi();

            try
            {
                // Đọc lại danh sách để hiển thị tài khoản vừa tạo
                TaiDanhSachTaiKhoan();
                dgvTaiKhoan.ClearSelection();
            }
            catch (Exception ex)
            {
                // Phân biệt lỗi tải bảng với lỗi thêm tài khoản
                MessageBox.Show(
                    "Tài khoản đã được tạo, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Phải chọn tài khoản trước khi cập nhật
            if (!maNDDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật.");
                return;
            }

            try
            {
                string maVaiTro = cboVaiTro.SelectedValue as string;

                var service = new NguoiDungService();

                service.CapNhatTaiKhoan(
                    maNDDangChon.Value,
                    txtHoTen.Text,
                    maVaiTro,
                    chkHoatDong.Checked);
            }
            catch (Exception ex)
            {
                // Giữ thông tin đang nhập để người dùng sửa
                MessageBox.Show(
                    ex.Message,
                    "Không thể cập nhật",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Dữ liệu đã được lưu thành công
            MessageBox.Show("Cập nhật tài khoản thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu mới nhất
                TaiDanhSachTaiKhoan();
                dgvTaiKhoan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật tài khoản, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!maNDDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                return;
            }

            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa tài khoản \"" + txtTenDangNhap.Text + "\"?",
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
                var service = new NguoiDungService();
                service.XoaTaiKhoan(maNDDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Xóa tài khoản thành công!");
            LamMoi();

            try
            {
                TaiDanhSachTaiKhoan();
                dgvTaiKhoan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa tài khoản, nhưng không thể tải lại danh sách: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
