using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Services;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BuffetManager.Forms
{
    public partial class frmThanhToan : Form
    {
        private int maLuot;
        private LUOTPHUCVU luot;
        private decimal total;
        private bool ready, saving;
        private readonly ThanhToanService service = new ThanhToanService();
        public frmThanhToan() : this(0)
        {
        }

        public frmThanhToan(int id)
        {
            InitializeComponent();

            maLuot = id;

            dgvChiTietHoaDon.AutoGenerateColumns = false;

            Load += (s, e) =>
            {
                if (!FormHelper.Run(() =>
                {
                    var p = new PhucVuService();
                    luot = p.Luot(id);
                    lblThongTinBan.Text = "Bàn: " + p.TenBan(id);
                    lblHinhThuc.Text = "Hình thức: " + luot.HinhThuc;
                    lblGioMo.Text = "Giờ mở: " + luot.GioMo.ToString("dd/MM/yyyy HH:mm");
                    pnlPhatThua.Visible = luot.HinhThuc == "BUFFET";
                    lblDonGiaPhat.Text = "Phạt/kg: " + (luot.GiaPhatMoiKg ?? 0).ToString("N0");
                    FormHelper.Combo(cboPhuongThuc, "TIENMAT", "Tiền mặt", "CHUYENKHOAN", "Chuyển khoản");
                    ready = true;
                    Reload();
                }))
                    Close();
            };
            nudKhoiLuongThua.ValueChanged += (s, e) =>
            {
                if (ready)
                    FormHelper.Run(Reload);
            };
            cboPhuongThuc.SelectionChangeCommitted += (s, e) =>
            {
                chkDaNhanChuyenKhoan.Checked = false;
                Payment();
            };
            nudTienKhachDua.ValueChanged += (s, e) => Payment();
            btnThanhToan.Click += (s, e) => Pay();
            btnDong.Click += (s, e) => Close();
        }

        private void Reload()
        {
            var list = service.DuTinh(maLuot, luot.HinhThuc == "BUFFET" ? nudKhoiLuongThua.Value : 0);
            total = list.Sum(x => x.ThanhTien);
            dgvChiTietHoaDon.DataSource = list;

            lblTienPhat.Text = "Tiền phạt: " + list.Where(x => x.LoaiDong == "PHAT_THUA").Sum(x => x.ThanhTien).ToString("N0") + " đ";
            lblTongThanhToan.Text = "Tổng thanh toán: " + total.ToString("N0") + " đ";
            chkDaNhanChuyenKhoan.Checked = false;
            Payment();
        }

        private void Payment()
        {
            if (!ready)
                return;
            bool transfer = FormHelper.Value(cboPhuongThuc) == "CHUYENKHOAN";
            nudTienKhachDua.Enabled = !transfer;
            chkDaNhanChuyenKhoan.Visible = transfer;
            picQR.Visible = transfer;
            if (transfer) ShowQR("Ban " + luot.MaLuot + " - " + total.ToString("0"));
            lblTienThua.Text = transfer ? "Tiền thừa: 0 đ" : nudTienKhachDua.Value < total ? "Còn thiếu: " + (total - nudTienKhachDua.Value).ToString("N0") + " đ" : "Tiền thừa: " + (nudTienKhachDua.Value - total).ToString("N0") + " đ";
            btnThanhToan.Enabled = !saving && UserSession.CoQuyen("THANH_TOAN");
        }

        private void Pay()
        {
            if (saving || !FormHelper.Confirm("Xác nhận thanh toán " + total.ToString("N0") + " đ và đóng toàn bộ bàn của lượt này?"))
                return;
            saving = true;
            Payment();
            int id = 0;
            bool ok = FormHelper.Run(() => id = service.ThanhToan(new ThanhToanDTO { MaLuot = maLuot, KhoiLuongThua = luot.HinhThuc == "BUFFET" ? nudKhoiLuongThua.Value : 0, PhuongThuc = FormHelper.Value(cboPhuongThuc), TienKhachDua = nudTienKhachDua.Value, DaNhanChuyenKhoan = chkDaNhanChuyenKhoan.Checked, TongTienDaXem = total }));
            saving = false;
            Payment();

            if (ok)
            {
                MessageBox.Show(
                    "Thanh toán thành công. Mã hóa đơn: " + id);

                Hide();

                FormHelper.Run(() =>
                {
                    using (var form = new frmReportHoaDon(id))
                    {
                        form.ShowDialog(this);
                    }
                });

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ShowQR(string text)
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.M))
            using (var qr = new QRCode(data))
            {
                var old = picQR.Image;
                picQR.Image = qr.GetGraphic(8);
                old?.Dispose();
            }
        }
    }
}
