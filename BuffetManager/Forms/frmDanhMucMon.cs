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
    public partial class frmDanhMucMon : Form
    {
        // null nghĩa là chưa chọn danh mục
        private int? maDMDangChon = null;

        public frmDanhMucMon()
        {
            InitializeComponent();

            dgvDanhMucMon.AutoGenerateColumns = false;
        }

        // Hiển thị tên tiếng Việt, giữ mã để lưu vào database
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

        // Hiển thị danh mục món lên bảng
        private void TaiDanhSachDanhMuc()
        {
            var repository = new DanhMucMonRepository();

            // Chọn các thuộc tính cần hiển thị, không lấy cột quan hệ
            var danhSach = repository.LayDanhSach()
                .Select(dm => new
                {
                    dm.MaDM,
                    dm.TenDM,
                    dm.BoPhan,
                    TenBoPhan = dm.BoPhan == "BEP" ? "Bếp" : "Pha chế"
                })
                .ToList();

            dgvDanhMucMon.DataSource = danhSach;
        }

        private void frmDanhMucMon_Load(object sender, EventArgs e)
        {
            try
            {
                TaiBoPhan();
                TaiDanhSachDanhMuc();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh mục món: " + ex.Message,
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
                // Lấy mã bộ phận; chưa chọn thì giá trị là null
                string boPhan = cboBoPhan.SelectedValue as string;

                // Service kiểm tra quyền và dữ liệu trước khi lưu
                var service = new DanhMucMonService();

                service.Them(
                    txtTenDanhMuc.Text,
                    boPhan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm danh mục",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Dữ liệu đã được lưu thành công
            MessageBox.Show("Thêm danh mục thành công!");
            txtTenDanhMuc.Clear();
            txtTenDanhMuc.Focus();

            try
            {
                // Tải lại bảng để hiển thị danh mục vừa thêm
                TaiDanhSachDanhMuc();
                dgvDanhMucMon.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm danh mục, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvDanhMucMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi bấm tiêu đề cột
            if (e.RowIndex < 0)
            {
                return;
            }

            var dong = dgvDanhMucMon.Rows[e.RowIndex];

            // Lấy thông tin từ các cột của dòng được chọn
            maDMDangChon = Convert.ToInt32(dong.Cells["MaDM"].Value);
            txtTenDanhMuc.Text = Convert.ToString(dong.Cells["TenDM"].Value);
            cboBoPhan.SelectedValue =
                Convert.ToString(dong.Cells["BoPhan"].Value);

            // Chuyển sang trạng thái sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Đưa giao diện về trạng thái thêm mới
        private void LamMoi()
        {
            maDMDangChon = null;

            txtTenDanhMuc.Clear();
            cboBoPhan.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvDanhMucMon.ClearSelection();
            txtTenDanhMuc.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn danh mục trước khi sửa
            if (!maDMDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa.");
                return;
            }

            try
            {
                // Lấy mã bộ phận đang chọn
                string boPhan = cboBoPhan.SelectedValue as string;

                var service = new DanhMucMonService();

                service.Sua(
                    maDMDangChon.Value,
                    txtTenDanhMuc.Text,
                    boPhan);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa danh mục",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật danh mục thành công!");
            LamMoi();

            try
            {
                // Hiển thị lại dữ liệu mới nhất
                TaiDanhSachDanhMuc();
                dgvDanhMucMon.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật danh mục, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn danh mục trước khi xóa
            if (!maDMDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa.");
                return;
            }

            // Xác nhận trước khi thực hiện
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa danh mục có mã "
                    + maDMDangChon.Value + "?",
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
                // Service kiểm tra quyền; Repository kiểm tra món liên quan
                var service = new DanhMucMonService();
                service.Xoa(maDMDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa danh mục",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Xóa danh mục thành công!");
            LamMoi();

            try
            {
                // Tải lại danh sách sau khi xóa
                TaiDanhSachDanhMuc();
                dgvDanhMucMon.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xóa danh mục, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
