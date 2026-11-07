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
    public partial class frmNhapKho : Form
    {
        // Danh sách dòng nhập tạm, chưa ghi xuống database
        private BindingList<ChiTietNhapDTO> chiTietNhap =
            new BindingList<ChiTietNhapDTO>();
        // Đánh dấu khi đang lưu phiếu
        private bool dangLuuPhieu = false;

        public frmNhapKho()
        {
            InitializeComponent();

            dgvChiTietNhap.AutoGenerateColumns = false;
        }

        // Nạp nguyên liệu và giữ đối tượng DTO để dùng khi chọn
        private void TaiNguyenLieu()
        {
            var repository = new NguyenLieuRepository();

            cboNguyenLieu.DisplayMember = nameof(NguyenLieuDTO.TenNL);
            cboNguyenLieu.ValueMember = nameof(NguyenLieuDTO.MaNL);
            cboNguyenLieu.FormattingEnabled = true;
            cboNguyenLieu.DataSource = repository.LayDanhSach();
            cboNguyenLieu.SelectedIndex = -1;

            lblDonVi.Text = "Đơn vị: —";
        }

        // Gắn danh sách nhập tạm vào bảng
        private void KhoiTaoBangChiTiet()
        {
            // Gắn danh sách nguyên liệu nhập tạm
            dgvChiTietNhap.DataSource = chiTietNhap;

            // Trạng thái ban đầu
            lblTongTien.Text = "Tổng tiền: 0 đồng";
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                TaiNguyenLieu();
                KhoiTaoBangChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu nhập kho: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void cboNguyenLieu_Format(object sender, ListControlConvertEventArgs e)
        {
            // Hiển thị tên kèm bộ phận và đơn vị
            var nguyenLieu = e.ListItem as NguyenLieuDTO;

            if (nguyenLieu != null)
            {
                e.Value = nguyenLieu.TenNL + " — "
                    + nguyenLieu.TenBoPhan
                    + " (" + nguyenLieu.DonVi + ")";
            }
        }

        private void cboNguyenLieu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Lấy nguyên liệu được người dùng chọn
            var nguyenLieu = cboNguyenLieu.SelectedItem as NguyenLieuDTO;

            lblDonVi.Text = nguyenLieu == null
                ? "Đơn vị: —"
                : "Đơn vị: " + nguyenLieu.DonVi;

            // Đưa số lượng và đơn giá về mặc định khi chọn nguyên liệu
            nudSoLuong.Value = 1;
            nudDonGia.Value = 0;
        }

        // Tính tổng tiền từ các dòng nhập tạm
        private void CapNhatTongTien()
        {
            decimal tongTien = chiTietNhap.Sum(ct => ct.ThanhTien);
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " đồng";

            // Chỉ cho lưu khi có chi tiết và có quyền
            btnLuuPhieu.Enabled = chiTietNhap.Count > 0
                && UserSession.CoQuyen("QUANLY_KHO");
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền thao tác
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.");
                return;
            }

            var nguyenLieu = cboNguyenLieu.SelectedItem as NguyenLieuDTO;

            if (nguyenLieu == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.");
                return;
            }

            // Mỗi nguyên liệu chỉ có một dòng trong phiếu
            if (chiTietNhap.Any(ct => ct.MaNL == nguyenLieu.MaNL))
            {
                MessageBox.Show(
                    "Nguyên liệu đã có trong phiếu. "
                    + "Hãy xóa dòng cũ rồi thêm lại nếu cần thay đổi.");
                return;
            }

            decimal soLuong = nudSoLuong.Value;
            decimal donGia = nudDonGia.Value;

            // Kiểm tra số lượng và đơn giá
            if (soLuong < 0.001m || soLuong > 1000000m ||
                soLuong != decimal.Round(soLuong, 3))
            {
                MessageBox.Show(
                    "Số lượng phải từ 0,001 đến 1.000.000, tối đa 3 số thập phân.");
                return;
            }

            if (donGia < 0 || donGia > 100000000m ||
                donGia != decimal.Truncate(donGia))
            {
                MessageBox.Show(
                    "Đơn giá phải là số nguyên từ 0 đến 100.000.000 đồng.");
                return;
            }

            // Chỉ thêm vào danh sách trong bộ nhớ
            chiTietNhap.Add(new ChiTietNhapDTO
            {
                MaNL = nguyenLieu.MaNL,
                TenNL = nguyenLieu.TenNL,
                DonVi = nguyenLieu.DonVi,
                SoLuong = soLuong,
                DonGia = donGia
            });

            // BindingList tự cập nhật bảng khi thêm dòng
            CapNhatTongTien();
            dgvChiTietNhap.ClearSelection();

            // Chuẩn bị nhập nguyên liệu tiếp theo
            cboNguyenLieu.SelectedIndex = -1;
            lblDonVi.Text = "Đơn vị: —";
            nudSoLuong.Value = 1;
            nudDonGia.Value = 0;
        }

        private void dgvChiTietNhap_SelectionChanged(object sender, EventArgs e)
        {
            // Chỉ bật nút khi có dòng được chọn và có quyền
            btnXoaDong.Enabled =
                dgvChiTietNhap.SelectedRows.Count > 0 &&
                UserSession.CoQuyen("QUANLY_KHO");
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền thao tác
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                MessageBox.Show("Bạn không có quyền quản lý kho.");
                return;
            }

            if (dgvChiTietNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
                return;
            }

            // Lấy đối tượng của dòng đang chọn
            var chiTiet = dgvChiTietNhap.SelectedRows[0]
                .DataBoundItem as ChiTietNhapDTO;

            if (chiTiet == null)
            {
                return;
            }

            // Chỉ xóa khỏi danh sách tạm, không tác động database
            chiTietNhap.Remove(chiTiet);

            // Tính lại tổng tiền và trạng thái nút Lưu
            CapNhatTongTien();
            dgvChiTietNhap.ClearSelection();
            btnXoaDong.Enabled = false;
        }

        // Hỏi trước khi bỏ dữ liệu đang nhập
        private bool XacNhanBoDuLieu()
        {
            bool coDuLieu =
                chiTietNhap.Count > 0 ||
                !string.IsNullOrWhiteSpace(txtNhaCungCap.Text) ||
                !string.IsNullOrWhiteSpace(txtGhiChu.Text) ||
                cboNguyenLieu.SelectedIndex >= 0 ||
                nudSoLuong.Value != 1 ||
                nudDonGia.Value != 0;

            if (!coDuLieu)
            {
                return true;
            }

            return MessageBox.Show(
                "Phiếu có dữ liệu chưa lưu. Bạn có muốn bỏ dữ liệu này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        // Xóa dữ liệu tạm để bắt đầu phiếu mới
        private void LamMoiPhieu()
        {
            chiTietNhap.Clear();

            txtNhaCungCap.Clear();
            txtGhiChu.Clear();
            cboNguyenLieu.SelectedIndex = -1;
            lblDonVi.Text = "Đơn vị: —";
            nudSoLuong.Value = 1;
            nudDonGia.Value = 0;

            CapNhatTongTien();
            dgvChiTietNhap.ClearSelection();
            btnXoaDong.Enabled = false;

            txtNhaCungCap.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Chỉ xóa dữ liệu tạm khi người dùng đồng ý
            if (!XacNhanBoDuLieu())
            {
                return;
            }

            LamMoiPhieu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Việc xác nhận sẽ xử lý chung trong FormClosing
            this.Close();
        }

        private void frmNhapKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Áp dụng cho cả nút Đóng, nút X và Alt + F4
            if (!XacNhanBoDuLieu())
            {
                e.Cancel = true;
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            // Không xử lý thêm lần nữa khi đang lưu
            if (dangLuuPhieu)
            {
                return;
            }

            if (chiTietNhap.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm nguyên liệu vào phiếu.");
                return;
            }

            // Xác nhận trước khi ghi dữ liệu và tăng tồn kho
            var ketQua = MessageBox.Show(
                "Bạn có chắc muốn lưu phiếu và tăng tồn kho?",
                "Xác nhận nhập kho",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            int maPN;

            dangLuuPhieu = true;
            btnLuuPhieu.Enabled = false;

            try
            {
                var service = new NhapKhoService();

                // ToList tạo danh sách các dòng để chuyển sang Service
                maPN = service.LuuPhieu(
                    txtNhaCungCap.Text,
                    txtGhiChu.Text,
                    chiTietNhap.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu phiếu: " + ex.Message,
                    "Lỗi nhập kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Giữ dữ liệu để người dùng kiểm tra và thử lại
                return;
            }
            finally
            {
                dangLuuPhieu = false;
                CapNhatTongTien();
            }

            // Đã lưu thành công: xóa phiếu tạm để tránh lưu lại cùng dữ liệu
            LamMoiPhieu();

            MessageBox.Show(
                "Lưu phiếu nhập thành công!\nMã phiếu: " + maPN,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
