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
    public partial class frmBan : Form
    {
        // null nghĩa là chưa chọn bàn
        private int? maBanDangChon = null;

        public frmBan()
        {
            InitializeComponent();

            // Không tự động sinh thêm cột
            dgvBan.AutoGenerateColumns = false;
        }

        // Nạp danh sách khu vực vào ComboBox
        private void TaiKhuVuc()
        {
            var repository = new KhuVucRepository();

            cboKhuVuc.DisplayMember = "TenKV";
            cboKhuVuc.ValueMember = "MaKV";
            cboKhuVuc.DataSource = repository.LayDanhSach();

            // Yêu cầu người dùng tự chọn khu vực
            cboKhuVuc.SelectedIndex = -1;
        }

        // Hiển thị danh sách bàn
        private void TaiDanhSachBan()
        {
            var repository = new BanRepository();

            dgvBan.DataSource = repository.LayDanhSach();
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            try
            {
                TaiKhuVuc();
                TaiDanhSachBan();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu bàn: " + ex.Message,
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
            // Phải chọn khu vực trước khi thêm
            if (cboKhuVuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực.");
                cboKhuVuc.Focus();
                return;
            }

            try
            {
                // Lấy mã khu vực và số chỗ từ giao diện
                int maKV = Convert.ToInt32(cboKhuVuc.SelectedValue);
                int soCho = Convert.ToInt32(nudSoCho.Value);

                var service = new BanService();

                service.Them(
                    txtTenBan.Text,
                    maKV,
                    soCho,
                    chkHoatDong.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm bàn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Bàn đã được lưu thành công
            MessageBox.Show("Thêm bàn thành công!");
            txtTenBan.Clear();
            txtTenBan.Focus();

            try
            {
                // Tải lại bảng để hiển thị bàn vừa thêm
                TaiDanhSachBan();
                dgvBan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm bàn, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            // Lấy thông tin bàn của dòng được chọn
            var ban = dgvBan.Rows[e.RowIndex].DataBoundItem as BanDTO;

            if (ban == null)
            {
                return;
            }

            // Ghi nhớ mã bàn và đưa thông tin lên các ô nhập
            maBanDangChon = ban.MaBan;
            txtTenBan.Text = ban.TenBan;
            cboKhuVuc.SelectedValue = ban.MaKV;
            nudSoCho.Value = ban.SoCho;
            chkHoatDong.Checked = ban.HoatDong;

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm bàn
        private void LamMoi()
        {
            maBanDangChon = null;

            txtTenBan.Clear();
            cboKhuVuc.SelectedIndex = -1;
            nudSoCho.Value = 4;
            chkHoatDong.Checked = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvBan.ClearSelection();
            txtTenBan.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn bàn trước khi sửa
            if (!maBanDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa.");
                return;
            }

            // Phải chọn khu vực
            if (cboKhuVuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực.");
                cboKhuVuc.Focus();
                return;
            }

            try
            {
                int maKV = Convert.ToInt32(cboKhuVuc.SelectedValue);
                int soCho = Convert.ToInt32(nudSoCho.Value);

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new BanService();

                service.Sua(
                    maBanDangChon.Value,
                    txtTenBan.Text,
                    maKV,
                    soCho,
                    chkHoatDong.Checked);
            }
            catch (Exception ex)
            {
                // Giữ thông tin để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa bàn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật bàn thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi cập nhật
                TaiDanhSachBan();
                dgvBan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật bàn, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn bàn trước khi xóa
            if (!maBanDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa bàn có mã "
                    + maBanDangChon.Value + "?",
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
                // Service kiểm tra quyền; Repository kiểm tra lịch sử của bàn
                var service = new BanService();
                service.Xoa(maBanDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa bàn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa bàn thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachBan();
                dgvBan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa bàn, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
