using BuffetManager.Helpers;
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
    public partial class frmComboMon : Form
    {
        // Ghi nhớ combo và món đang được chọn
        private int? maComboDangChon = null;
        private int? maMonDangChon = null;

        public frmComboMon()
        {
            InitializeComponent();

            dgvComboMon.AutoGenerateColumns = false;
        }

        // Nạp dữ liệu cho hai ComboBox
        private void TaiDuLieu()
        {
            var comboRepository = new ComboRepository();

            cboCombo.DisplayMember = "TenCombo";
            cboCombo.ValueMember = "MaCombo";
            cboCombo.DataSource = comboRepository.LayDanhSach();
            cboCombo.SelectedIndex = -1;

            var monRepository = new MonAnRepository();

            // Hiển thị thêm danh mục để phân biệt các món trùng tên
            var danhSachMon = monRepository.LayDanhSach()
                .Select(mon => new
                {
                    mon.MaMon,
                    TenHienThi = mon.TenMon + " — " + mon.TenDM
                        + (mon.DangBan ? "" : " (Ngừng bán)")
                })
                .ToList();

            cboMonAn.DisplayMember = "TenHienThi";
            cboMonAn.ValueMember = "MaMon";
            cboMonAn.DataSource = danhSachMon;
            cboMonAn.SelectedIndex = -1;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        // Hiển thị các món thuộc combo
        private void TaiDanhSachMon(int maCombo)
        {
            var repository = new ComboMonRepository();

            dgvComboMon.DataSource = repository.LayDanhSach(maCombo);

            // Giữ nguyên trạng thái chưa chọn món
            dgvComboMon.ClearSelection();
        }

        private void frmComboMon_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();

                // Chưa chọn combo: hiển thị bảng trống có đủ các cột
                TaiDanhSachMon(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu combo: " + ex.Message,
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

        private void cboCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Xóa lựa chọn cũ và khóa thao tác trong lúc tải
            maComboDangChon = null;
            maMonDangChon = null;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            cboMonAn.SelectedIndex = -1;
            nudSoLuong.Value = 1;

            try
            {
                if (cboCombo.SelectedValue == null)
                {
                    TaiDanhSachMon(0);
                    return;
                }

                int maCombo = Convert.ToInt32(cboCombo.SelectedValue);

                // Tải xong mới ghi nhận combo đang thao tác
                TaiDanhSachMon(maCombo);
                maComboDangChon = maCombo;

                btnThem.Enabled = UserSession.CoQuyen("QUANLY_DANHMUC");
            }
            catch (Exception ex)
            {
                // Không để bảng còn hiển thị dữ liệu của combo trước
                dgvComboMon.DataSource = null;

                MessageBox.Show(
                    "Không thể tải món thuộc combo: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Phải chọn combo và tải dữ liệu thành công
            if (!maComboDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn combo.");
                return;
            }

            // Phải chọn món cần thêm
            if (cboMonAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn.");
                cboMonAn.Focus();
                return;
            }

            try
            {
                int maMon = Convert.ToInt32(cboMonAn.SelectedValue);
                int soLuong = Convert.ToInt32(nudSoLuong.Value);

                var service = new ComboMonService();

                service.Them(
                    maComboDangChon.Value,
                    maMon,
                    soLuong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm món vào combo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Thêm món vào combo thành công!");

            // Xóa lựa chọn món, giữ nguyên combo để tiếp tục thêm
            maMonDangChon = null;
            cboMonAn.SelectedIndex = -1;
            // Cho chọn món mới khi chuyển combo
            cboMonAn.Enabled = true;
            nudSoLuong.Value = 1;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            try
            {
                // Hiển thị lại các món thuộc combo
                TaiDanhSachMon(maComboDangChon.Value);
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

        private void dgvComboMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua tiêu đề cột hoặc khi chưa chọn combo
            if (e.RowIndex < 0 || !maComboDangChon.HasValue)
            {
                return;
            }

            var mon = dgvComboMon.Rows[e.RowIndex]
                                .DataBoundItem as ComboMonDTO;

            if (mon == null || mon.MaCombo != maComboDangChon.Value)
            {
                return;
            }

            // Ghi nhớ món và hiển thị số lượng hiện tại
            maMonDangChon = mon.MaMon;
            cboMonAn.SelectedValue = mon.MaMon;
            nudSoLuong.Value = mon.SoLuong;

            // Khi sửa chỉ thay đổi số lượng, không đổi sang món khác
            cboMonAn.Enabled = false;
            btnThem.Enabled = false;

            bool coQuyen = UserSession.CoQuyen("QUANLY_DANHMUC");
            btnSua.Enabled = coQuyen;
            btnXoa.Enabled = coQuyen;
        }

        // Bỏ chọn món, giữ nguyên combo đang thao tác
        private void LamMoi()
        {
            maMonDangChon = null;

            cboMonAn.SelectedIndex = -1;
            cboMonAn.Enabled = true;
            nudSoLuong.Value = 1;

            btnThem.Enabled =
                maComboDangChon.HasValue &&
                UserSession.CoQuyen("QUANLY_DANHMUC");

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvComboMon.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn combo và một dòng món trong bảng
            if (!maComboDangChon.HasValue || !maMonDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món trong combo cần sửa.");
                return;
            }

            try
            {
                int soLuong = Convert.ToInt32(nudSoLuong.Value);

                // Dùng mã món của dòng đã chọn, không lấy từ ComboBox
                var service = new ComboMonService();

                service.Sua(
                    maComboDangChon.Value,
                    maMonDangChon.Value,
                    soLuong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa số lượng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật số lượng thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách của combo hiện tại
                TaiDanhSachMon(maComboDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật số lượng, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn combo và một dòng món trong bảng
            if (!maComboDangChon.HasValue || !maMonDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món cần gỡ khỏi combo.");
                return;
            }

            // Xác nhận trước khi gỡ liên kết
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn gỡ món có mã "
                    + maMonDangChon.Value + " khỏi combo đang chọn?",
                "Xác nhận gỡ món",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Service kiểm tra quyền; Repository kiểm tra lượt sử dụng
                var service = new ComboMonService();

                service.Xoa(
                    maComboDangChon.Value,
                    maMonDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể gỡ món",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Gỡ món khỏi combo thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách của combo hiện tại
                TaiDanhSachMon(maComboDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã gỡ món, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
