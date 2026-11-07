using BuffetManager.Helpers;
using BuffetManager.Services;
using BuffetManager.Models;
using BuffetManager.Repositories;
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
    public partial class frmMoBan : Form
    {
        private readonly MoBanRepository moBanRepository = new MoBanRepository();
        private int? banChonTruoc;
        public frmMoBan() : this(null)
        {
        }

        public frmMoBan(int? maBan)
        {
            InitializeComponent();
            banChonTruoc = maBan;
            btnMoBan.Click += LuuMoBan;
        }

        // Khai báo ba hình thức dùng bữa
        private void TaiHinhThuc()
        {
            var danhSach = new[]
            {
                new
                {
                    Ma = "BUFFET",
                    Ten = "Buffet"
                },
                new
                {
                    Ma = "COMBO",
                    Ten = "Combo"
                },
                new
                {
                    Ma = "GOIMON",
                    Ten = "Gọi món"
                }
            };
            cboHinhThuc.DisplayMember = "Ten";
            cboHinhThuc.ValueMember = "Ma";
            cboHinhThuc.DataSource = danhSach;
            // Mặc định chọn buffet
            cboHinhThuc.SelectedIndex = 0;
        }

        // Chỉ hiển thị phần vé khi chọn buffet
        private void CapNhatHienThi()
        {
            string hinhThuc = cboHinhThuc.SelectedValue as string;
            pnlBuffet.Visible = hinhThuc == "BUFFET";
            // Chỉ cho chọn lượt đặt khi khách đã đặt trước
            cboDatBan.Enabled = chkCoDatTruoc.Checked;
        }

        private void frmMoBan_Load(object sender, EventArgs e)
        {
            try
            {
                TaiHinhThuc();
                TaiDanhSachBan();
                TaiDanhSachGoiBuffet();
                if (banChonTruoc.HasValue)
                    cboBan.SelectedValue = banChonTruoc.Value;
                TaiDatBanTheoBan();
                nudDuoi1m.Value = 0;
                nudTu1mDen1m3.Value = 0;
                nudTren1m3.Value = 0;
                CapNhatTienVe();
                // Chưa bật cho đến khi có phần lưu
                btnMoBan.Enabled = UserSession.CoQuyen("MO_BAN");
                CapNhatHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu mở bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cboHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void chkCoDatTruoc_CheckedChanged(object sender, EventArgs e)
        {
            // Bỏ lựa chọn cũ khi chuyển về khách đến trực tiếp
            if (!chkCoDatTruoc.Checked)
            {
                cboDatBan.SelectedIndex = -1;
            }

            CapNhatHienThi();
        }

        // Tải bàn chưa có khách sử dụng
        private void TaiDanhSachBan()
        {
            cboBan.DisplayMember = "TenBan";
            cboBan.ValueMember = "MaBan";
            cboBan.DataSource = moBanRepository.LayDanhSachBan();
            cboBan.SelectedIndex = -1;
        }

        // Tải các gói buffet hợp lệ
        private void TaiDanhSachGoiBuffet()
        {
            cboGoiBuffet.DisplayMember = "TenGoi";
            cboGoiBuffet.ValueMember = "MaGoi";
            cboGoiBuffet.DataSource = moBanRepository.LayDanhSachGoiBuffet();
            cboGoiBuffet.SelectedIndex = -1;
        }

        // Tải lượt đặt đang chờ của bàn được chọn
        private void TaiDatBanTheoBan()
        {
            cboDatBan.DataSource = null;
            var ban = cboBan.SelectedItem as BAN;
            if (ban == null)
            {
                chkCoDatTruoc.Checked = false;
                chkCoDatTruoc.Enabled = false;
                CapNhatHienThi();
                return;
            }

            var danhSach = moBanRepository.LayDatBanTheoBan(ban.MaBan);
            // Tạo nội dung dễ nhận biết khi chọn lượt đặt
            cboDatBan.DisplayMember = "HienThi";
            cboDatBan.ValueMember = "MaDatBan";
            cboDatBan.DataSource = danhSach.Select(d => new { d.MaDatBan, HienThi = d.HoTen + " - " + d.SDT + " - " + d.GioDen.ToString("dd/MM/yyyy HH:mm") }).ToList();
            bool coDatTruoc = danhSach.Count > 0;
            // Bàn đã đặt phải đón đúng lượt đặt đang chờ
            chkCoDatTruoc.Checked = coDatTruoc;
            chkCoDatTruoc.Enabled = false;
            cboDatBan.SelectedIndex = coDatTruoc ? 0 : -1;
            CapNhatHienThi();
        }

        private void cboBan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                TaiDatBanTheoBan();
            }
            catch (Exception ex)
            {
                // Xóa lựa chọn để tránh dùng dữ liệu đặt bàn cũ
                cboBan.SelectedIndex = -1;
                cboDatBan.DataSource = null;
                chkCoDatTruoc.Checked = false;
                chkCoDatTruoc.Enabled = false;
                CapNhatHienThi();
                MessageBox.Show("Không thể tải lượt đặt: " + ex.Message);
            }
        }

        // Tính tiền vé dự kiến để hiển thị trên Form
        private void CapNhatTienVe()
        {
            int duoi1m = Convert.ToInt32(nudDuoi1m.Value);
            int tu1mDenDuoi1m3 = Convert.ToInt32(nudTu1mDen1m3.Value);
            int tu1m3 = Convert.ToInt32(nudTren1m3.Value);
            int tongKhach = duoi1m + tu1mDenDuoi1m3 + tu1m3;
            lblTongKhach.Text = "Tổng khách: " + tongKhach;
            var goi = cboGoiBuffet.SelectedItem as GOIBUFFET;
            if (goi == null)
            {
                lblTienVe.Text = "Tiền vé: Chưa chọn gói";
                return;
            }

            // Dưới 1 m: miễn phí
            // Từ 1 m đến dưới 1,3 m: thu 50%
            // Từ 1,3 m trở lên: thu 100%
            decimal tongTien = tu1mDenDuoi1m3 * Math.Round(goi.GiaNguoiLon * 0.5m, 2, MidpointRounding.AwayFromZero) + tu1m3 * goi.GiaNguoiLon;
            lblTienVe.Text = "Tiền vé: " + tongTien.ToString("#,##0.##") + " đ";
        }

        private void cboGoiBuffet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTienVe();
        }

        private void SoKhach_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTienVe();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LuuMoBan(object sender, EventArgs e)
        {
            if (!FormHelper.Confirm("Mở bàn theo hình thức đã chọn?"))
                return;
            btnMoBan.Enabled = false;
            int id = 0;
            bool ok = FormHelper.Run(() =>
            {
                var ban = cboBan.SelectedItem as BAN;
                var goi = cboGoiBuffet.SelectedItem as GOIBUFFET;
                id = new MoBanService().MoBan(new MoBanDTO { MaBan = ban == null ? 0 : ban.MaBan, HinhThuc = cboHinhThuc.SelectedValue as string, MaDatBan = chkCoDatTruoc.Checked && cboDatBan.SelectedValue is int ? (int? )cboDatBan.SelectedValue : null, MaGoi = goi == null ? (int? )null : goi.MaGoi, SoKhachDuoi1m = (int)nudDuoi1m.Value, SoKhachTu1mDenDuoi1m3 = (int)nudTu1mDen1m3.Value, SoKhachTu1m3 = (int)nudTren1m3.Value });
            });
            btnMoBan.Enabled = UserSession.CoQuyen("MO_BAN");
            if (ok)
            {
                MessageBox.Show("Đã mở bàn. Mã lượt: " + id);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
