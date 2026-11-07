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
    public partial class frmDinhLuong : Form
    {
        // Ghi nhớ món và nguyên liệu đang thao tác
        private int? maMonDangChon = null;
        private int? maNLDangChon = null;

        public frmDinhLuong()
        {
            InitializeComponent();

            dgvDinhLuong.AutoGenerateColumns = false;
        }

        // Nạp danh sách món để chọn cấu hình định lượng
        private void TaiMonAn()
        {
            var repository = new MonAnRepository();

            // Kèm danh mục để phân biệt các món trùng tên
            var danhSach = repository.LayDanhSach()
                .Select(mon => new
                {
                    mon.MaMon,
                    TenHienThi = mon.TenMon + " — " + mon.TenDM
                        + (mon.DangBan ? "" : " (Ngừng bán)")
                })
                .ToList();

            cboMonAn.DisplayMember = "TenHienThi";
            cboMonAn.ValueMember = "MaMon";
            cboMonAn.DataSource = danhSach;
            cboMonAn.SelectedIndex = -1;

            // Nguyên liệu sẽ được tải theo bộ phận của món
            cboNguyenLieu.DataSource = null;
            cboNguyenLieu.Enabled = false;

            lblDonVi.Text = "Đơn vị: —";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        // Hiển thị công thức nguyên liệu của món được chọn
        private void TaiDanhSachDinhLuong(int maMon)
        {
            var repository = new DinhLuongRepository();

            dgvDinhLuong.DataSource = repository.LayDanhSach(maMon);

            dgvDinhLuong.ClearSelection();
        }

        private void frmDinhLuong_Load(object sender, EventArgs e)
        {
            try
            {
                TaiMonAn();

                // Chưa chọn món: bảng trống nhưng vẫn có tiêu đề cột
                TaiDanhSachDinhLuong(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu định lượng: " + ex.Message,
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

        private void cboMonAn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Xóa lựa chọn cũ và khóa thao tác trong lúc tải
            maMonDangChon = null;
            maNLDangChon = null;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            cboNguyenLieu.DataSource = null;
            cboNguyenLieu.Enabled = false;
            lblDonVi.Text = "Đơn vị: —";
            nudLuongCan.Value = 0.100m;

            try
            {
                if (cboMonAn.SelectedValue == null)
                {
                    TaiDanhSachDinhLuong(0);
                    return;
                }

                int maMon = Convert.ToInt32(cboMonAn.SelectedValue);

                // Lấy nguyên liệu cùng bộ phận với món
                var repository = new NguyenLieuRepository();
                var nguyenLieu = repository.LayTheoMon(maMon);

                cboNguyenLieu.DisplayMember = nameof(NguyenLieuDTO.TenNL);
                cboNguyenLieu.ValueMember = nameof(NguyenLieuDTO.MaNL);
                cboNguyenLieu.DataSource = nguyenLieu;
                cboNguyenLieu.SelectedIndex = -1;

                // Tải công thức hiện tại
                TaiDanhSachDinhLuong(maMon);
                maMonDangChon = maMon;

                bool duocThem = nguyenLieu.Count > 0
                    && UserSession.CoQuyen("QUANLY_KHO");

                cboNguyenLieu.Enabled = duocThem;
                btnThem.Enabled = duocThem;
            }
            catch (Exception ex)
            {
                cboNguyenLieu.DataSource = null;
                dgvDinhLuong.DataSource = null;

                MessageBox.Show(
                    "Không thể tải định lượng: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cboNguyenLieu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Hiển thị đơn vị để người dùng nhập lượng đúng
            var nguyenLieu = cboNguyenLieu.SelectedItem as NguyenLieuDTO;

            lblDonVi.Text = nguyenLieu == null
                ? "Đơn vị: —"
                : "Đơn vị: " + nguyenLieu.DonVi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Phải chọn món và tải dữ liệu thành công
            if (!maMonDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món ăn.");
                return;
            }

            // Phải chọn nguyên liệu cần thêm
            if (cboNguyenLieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.");
                cboNguyenLieu.Focus();
                return;
            }

            try
            {
                int maNL = Convert.ToInt32(cboNguyenLieu.SelectedValue);

                // Service kiểm tra quyền và lượng cần trước khi lưu
                var service = new DinhLuongService();

                service.Them(
                    maMonDangChon.Value,
                    maNL,
                    nudLuongCan.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm định lượng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Thêm định lượng thành công!");

            // Bỏ chọn nguyên liệu, giữ nguyên món đang cấu hình
            maNLDangChon = null;
            cboNguyenLieu.SelectedIndex = -1;
            lblDonVi.Text = "Đơn vị: —";
            nudLuongCan.Value = 0.100m;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            try
            {
                // Hiển thị công thức sau khi thêm
                TaiDanhSachDinhLuong(maMonDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã thêm định lượng, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvDinhLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua tiêu đề cột hoặc khi chưa chọn món
            if (e.RowIndex < 0 || !maMonDangChon.HasValue)
            {
                return;
            }

            var dinhLuong = dgvDinhLuong.Rows[e.RowIndex]
                                       .DataBoundItem as DinhLuongDTO;

            if (dinhLuong == null ||
                dinhLuong.MaMon != maMonDangChon.Value)
            {
                return;
            }

            // Ghi nhớ nguyên liệu và hiển thị lượng hiện tại
            maNLDangChon = dinhLuong.MaNL;
            cboNguyenLieu.SelectedValue = dinhLuong.MaNL;
            nudLuongCan.Value = dinhLuong.LuongCan;
            lblDonVi.Text = "Đơn vị: " + dinhLuong.DonVi;

            // Khi sửa chỉ thay đổi lượng, không đổi nguyên liệu
            cboNguyenLieu.Enabled = false;
            btnThem.Enabled = false;

            bool coQuyen = UserSession.CoQuyen("QUANLY_KHO");
            btnSua.Enabled = coQuyen;
            btnXoa.Enabled = coQuyen;
        }

        // Bỏ chọn nguyên liệu, giữ nguyên món đang cấu hình
        private void LamMoi()
        {
            maNLDangChon = null;

            cboNguyenLieu.SelectedIndex = -1;
            nudLuongCan.Value = 0.100m;
            lblDonVi.Text = "Đơn vị: —";

            bool duocThem =
                maMonDangChon.HasValue &&
                cboNguyenLieu.Items.Count > 0 &&
                UserSession.CoQuyen("QUANLY_KHO");

            cboNguyenLieu.Enabled = duocThem;
            btnThem.Enabled = duocThem;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvDinhLuong.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Phải chọn món và một dòng nguyên liệu trong bảng
            if (!maMonDangChon.HasValue || !maNLDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa lượng.");
                return;
            }

            try
            {
                // Dùng mã nguyên liệu của dòng đã chọn
                var service = new DinhLuongService();

                service.Sua(
                    maMonDangChon.Value,
                    maNLDangChon.Value,
                    nudLuongCan.Value);
            }
            catch (Exception ex)
            {
                // Giữ nội dung để người dùng chỉnh lại
                MessageBox.Show(
                    ex.Message,
                    "Không thể sửa định lượng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Cập nhật định lượng thành công!");
            LamMoi();

            try
            {
                // Tải lại công thức của món hiện tại
                TaiDanhSachDinhLuong(maMonDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã cập nhật định lượng, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Phải chọn món và một dòng nguyên liệu trong bảng
            if (!maMonDangChon.HasValue || !maNLDangChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần gỡ.");
                return;
            }

            // Xác nhận trước khi gỡ khỏi công thức
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn gỡ nguyên liệu có mã "
                    + maNLDangChon.Value + " khỏi công thức món đang chọn?",
                "Xác nhận gỡ nguyên liệu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Service kiểm tra quyền; Repository xóa dòng định lượng
                var service = new DinhLuongService();

                service.Xoa(
                    maMonDangChon.Value,
                    maNLDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể gỡ nguyên liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show("Gỡ nguyên liệu khỏi công thức thành công!");
            LamMoi();

            try
            {
                // Tải lại công thức của món hiện tại
                TaiDanhSachDinhLuong(maMonDangChon.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã gỡ nguyên liệu, nhưng không thể tải lại danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
