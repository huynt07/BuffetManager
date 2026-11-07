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
    public partial class frmKhuVuc : Form
    {
        // null nghĩa là chưa chọn khu vực nào
        private int? maKVDangChon = null;
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        // Hiển thị danh sách khu vực lên bảng
        private void TaiDanhSachKhuVuc()
        {
            var repository = new KhuVucRepository();

            // Chỉ lấy các thuộc tính cần hiển thị,
            // tránh tự tạo cột cho các quan hệ trong entity
            dgvKhuVuc.AutoGenerateColumns = false;
            dgvKhuVuc.DataSource = repository.LayDanhSach();
        }

        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDanhSachKhuVuc();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải khu vực: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Đóng cửa sổ để trở về dashboard
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Service kiểm tra quyền, tên và gọi Repository để lưu
                var service = new KhuVucService();
                service.Them(txtTenKhuVuc.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm khu vực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Đến đây dữ liệu đã được lưu thành công
            MessageBox.Show("Thêm khu vực thành công!");
            txtTenKhuVuc.Clear();
            txtTenKhuVuc.Focus();

            try
            {
                // Tải lại bảng để hiển thị khu vực vừa thêm
                TaiDanhSachKhuVuc();
                dgvKhuVuc.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm khu vực, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            // Lấy khu vực của dòng được chọn
            var khuVuc = dgvKhuVuc.Rows[e.RowIndex]
                                 .DataBoundItem as KHUVUC;

            if (khuVuc == null)
            {
                return;
            }

            maKVDangChon = khuVuc.MaKV;
            txtTenKhuVuc.Text = khuVuc.TenKV;

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm mới
        private void LamMoi()
        {
            maKVDangChon = null;
            txtTenKhuVuc.Clear();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvKhuVuc.ClearSelection();
            txtTenKhuVuc.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn khu vực trước khi sửa
            if (!maKVDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn khu vực cần sửa.");
                return;
            }

            try
            {
                // Kiểm tra dữ liệu và lưu tên mới
                var service = new KhuVucService();

                service.Sua(
                    maKVDangChon.Value,
                    txtTenKhuVuc.Text);
            }
            catch (Exception ex)
            {
                // Giữ nội dung đang nhập để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa khu vực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật khu vực thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại danh sách sau khi sửa
                TaiDanhSachKhuVuc();
                dgvKhuVuc.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật khu vực, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn khu vực trước khi xóa
            if (!maKVDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn khu vực cần xóa.");
                return;
            }

            // Hỏi xác nhận trước khi xóa
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa khu vực có mã "
                    + maKVDangChon.Value + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            // Chọn No thì dừng lại
            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Service kiểm tra quyền; Repository kiểm tra bàn liên quan
                var service = new KhuVucService();
                service.Xoa(maKVDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa khu vực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa khu vực thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachKhuVuc();
                dgvKhuVuc.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa khu vực, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
