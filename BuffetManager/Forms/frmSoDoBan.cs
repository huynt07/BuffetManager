using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Services;

namespace BuffetManager.Forms
{
    public partial class frmSoDoBan : Form
    {
        private readonly PhucVuService service = new PhucVuService();
        private BanPhucVuDTO selected;
        private List<BanPhucVuDTO> data = new List<BanPhucVuDTO>();
        public frmSoDoBan()
        {
            InitializeComponent();

            Load += (s, e) => FormHelper.Run(() =>
            {
                var areas = service.KhuVuc();
                areas.Insert(0, new KHUVUC { MaKV = 0, TenKV = "Tất cả khu vực" });
                cboKhuVuc.DisplayMember = "TenKV";
                cboKhuVuc.ValueMember = "MaKV";
                cboKhuVuc.DataSource = areas;
                FormHelper.Combo(cboTrangThai, "", "Tất cả trạng thái", "Trống", "Trống", "Đã đặt", "Đã đặt", "Đang phục vụ", "Đang phục vụ");
                Reload();
            });
            cboKhuVuc.SelectionChangeCommitted += (s, e) => Render();
            cboTrangThai.SelectionChangeCommitted += (s, e) => Render();
            btnLamMoi.Click += (s, e) => FormHelper.Run(Reload);
            btnDong.Click += (s, e) => Close();
            btnLapHoaDon.Click += (s, e) => MoHoaDonTamTinh();
            btnGoiMon.Click += (s, e) => Open("GOI_MON");
            btnChuyenGopBan.Click += (s, e) => Open("CHUYEN_GOP_BAN");
            btnThanhToan.Click += (s, e) => Open("THANH_TOAN");
        }

        private void Reload()
        {
            data = service.DanhSach();
            selected = null;
            Render();
        }

        private void Render()
        {
            int area = cboKhuVuc.SelectedValue is int ? (int)cboKhuVuc.SelectedValue : 0;
            string status = FormHelper.Value(cboTrangThai);
            flpBan.SuspendLayout();
            // Chỉ xóa các nút bàn được tạo từ database.
            // Giữ nguyên các nút chức năng và label trong Designer.
            var cacNutBan = flpBan.Controls
                .Cast<Control>()
                .Where(c => c.Tag is BanPhucVuDTO)
                .ToList();

            foreach (var nut in cacNutBan)
            {
                flpBan.Controls.Remove(nut);
                nut.Dispose();
            }

            selected = null;
            SelectBan(null);
            foreach (var b in data.Where(x => (area == 0 || x.MaKV == area) && (status == "" || x.TrangThai == status)))
            {
                var button = new Guna.UI2.WinForms.Guna2Button
                {
                    Width = 170,
                    Height = 100,
                    Margin = new Padding(8),
                    BorderRadius = 8,
                    Text = b.TenBan + "\n" + b.TrangThai + "\n" + b.SoCho + " chỗ",
                    ForeColor = Color.White,
                    FillColor = b.MaLuot.HasValue ? Color.IndianRed : b.TrangThai == "Đã đặt" ? Color.DarkOrange : Color.SeaGreen,
                    Tag = b
                };
                button.Click += (s, e) => SelectBan((BanPhucVuDTO)((Control)s).Tag);
                flpBan.Controls.Add(button);
            }

            flpBan.ResumeLayout();
        }

        private void SelectBan(BanPhucVuDTO b)
        {
            selected = b;
            lblBanDangChon.Text = "Bàn đang chọn: " + (b == null ? "—" : b.TenBan);
            lblHinhThuc.Text = "Hình thức: " + (b == null ? "—" : b.HinhThuc);
            lblTrangThai.Text = "Trạng thái: " + (b == null ? "—" : b.TrangThai);
            bool active = b != null && b.MaLuot.HasValue;
            btnGoiMon.Enabled = active && UserSession.CoQuyen("GOI_MON");
            btnChuyenGopBan.Enabled = active && UserSession.CoQuyen("CHUYEN_GOP_BAN");
            btnLapHoaDon.Enabled = active &&
    (UserSession.CoQuyen("LAP_HOADON") ||
     UserSession.CoQuyen("THANH_TOAN"));
            btnThanhToan.Enabled = active && (UserSession.CoQuyen("THANH_TOAN") || UserSession.CoQuyen("LAP_HOADON"));
        }

        private void Open(string action)
        {
            if (selected == null)
                return;
            FormHelper.Run(() =>
            {
                using (Form f = action == "MO_BAN" ? (Form)new frmMoBan(selected.MaBan) : action == "GOI_MON" ? new frmGoiMon(selected.MaLuot.Value) : action == "CHUYEN_GOP_BAN" ? new frmChuyenGopBan(selected.MaBan, selected.MaLuot.Value) : (Form)new frmThanhToan(selected.MaLuot.Value))
                    f.ShowDialog(this);
                Reload();
            });
        }

        private void MoHoaDonTamTinh()
        {
            if (selected == null || !selected.MaLuot.HasValue)
            {
                MessageBox.Show(
                    "Hãy chọn bàn đang phục vụ để xem phiếu tạm tính.");
                return;
            }

            int maLuot = selected.MaLuot.Value;

            FormHelper.Run(() =>
            {
                using (var form = new frmReportHoaDon(maLuot, true))
                {
                    form.ShowDialog(this);
                }
            });
        }

    }
}
