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
    public partial class frmDatBan : Form
    {
        private readonly DatBanService datBanService =
    new DatBanService();
        private readonly DatBanRepository datBanRepository =
    new DatBanRepository();

        public frmDatBan()
        {
            InitializeComponent();

            dgvDatBan.AutoGenerateColumns = false;
        }

        private void frmDatBan_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDanhSachBan();

                // Giờ đến mặc định là thời điểm hiện tại
                // Mặc định đặt trước 30 phút
                dtpGioDen.Value = DateTime.Now.AddMinutes(30);
                nudSoKhach.Value = 1;

                // Chưa cho thao tác ghi dữ liệu ở bước này
                btnDatBan.Enabled = UserSession.CoQuyen("DAT_BAN");
                btnHuyDat.Enabled = false;

                TaiDanhSachDatBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu đặt bàn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        // Xóa nội dung nhập để chuẩn bị lượt đặt mới
        private void LamMoiNhapLieu()
        {
            cboBan.SelectedIndex = -1;
            txtHoTen.Clear();
            txtSDT.Clear();

            dtpGioDen.Value = DateTime.Now.AddMinutes(30);
            nudSoKhach.Value = 1;

            dgvDatBan.ClearSelection();
            dgvDatBan.CurrentCell = null;
            btnHuyDat.Enabled = false;

            txtHoTen.Focus();
        }

        // Tải bàn vào ComboBox
        private void TaiDanhSachBan()
        {
            cboBan.DisplayMember = "TenBan";
            cboBan.ValueMember = "MaBan";
            cboBan.DataSource = datBanRepository.LayDanhSachBan();

            cboBan.SelectedIndex = -1;
        }

        // Tải danh sách đặt bàn lên bảng
        private void TaiDanhSachDatBan()
        {
            dgvDatBan.DataSource = datBanRepository.LayDanhSach();

            // Giữ nguyên trạng thái chưa chọn bàn
            dgvDatBan.ClearSelection();
            dgvDatBan.CurrentCell = null;
        }

        // Tải lại bảng sau khi đã lưu hoặc hủy thành công
        private void TaiLaiSauThaoTac()
        {
            try
            {
                TaiDanhSachDatBan();
            }
            catch (Exception ex)
            {
                // Lỗi tải bảng không có nghĩa thao tác lưu bị thất bại
                MessageBox.Show(
                    "Dữ liệu đã được lưu nhưng chưa tải lại được danh sách: "
                    + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            int maDatBan;

            try
            {
                int maBan = cboBan.SelectedValue == null
                    ? 0
                    : Convert.ToInt32(cboBan.SelectedValue);

                maDatBan = datBanService.DatBan(
                    maBan,
                    txtHoTen.Text,
                    txtSDT.Text,
                    dtpGioDen.Value,
                    Convert.ToInt32(nudSoKhach.Value));
            }
            catch (Exception ex)
            {
                // Giữ nội dung nhập khi lưu thất bại
                MessageBox.Show(
                    ex.Message,
                    "Không thể đặt bàn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            LamMoiNhapLieu();
            TaiLaiSauThaoTac();

            MessageBox.Show(
                "Đặt bàn thành công. Mã đặt bàn: " + maDatBan,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            if (dgvDatBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lượt đặt cần hủy.");
                return;
            }

            var datBan = dgvDatBan.SelectedRows[0].DataBoundItem
                as DatBanDTO;

            if (datBan == null)
                return;

            var ketQua = MessageBox.Show(
                "Bạn có muốn hủy lượt đặt số " + datBan.MaDatBan
                + " tại bàn " + datBan.TenBan + "?",
                "Xác nhận hủy đặt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                // Service và Repository kiểm tra lại quyền, trạng thái
                datBanService.HuyDatBan(datBan.MaDatBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể hủy đặt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            LamMoiNhapLieu();
            TaiLaiSauThaoTac();

            MessageBox.Show("Đã hủy đặt bàn.");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                TaiDanhSachBan();
                TaiDanhSachDatBan();
                LamMoiNhapLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lại dữ liệu: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDatBan_SelectionChanged(object sender, EventArgs e)
        {
            btnHuyDat.Enabled = false;

            if (dgvDatBan.SelectedRows.Count == 0)
                return;

            var datBan = dgvDatBan.SelectedRows[0].DataBoundItem
                as DatBanDTO;

            if (datBan == null)
                return;

            // Chỉ bật nút khi có quyền và lượt đặt đang chờ
            btnHuyDat.Enabled =
                UserSession.CoQuyen("DAT_BAN") &&
                datBan.TrangThai == "CHO";
        }

    }
}
