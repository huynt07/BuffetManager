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
    public partial class frmGoiMon : Form
    {
        private readonly GoiMonService service = new GoiMonService();
        private readonly BindingList<DongGoiMonDTO> draft = new BindingList<DongGoiMonDTO>();
        private int maLuot;
        private bool saving;
        public frmGoiMon() : this(0)
        {
        }

        public frmGoiMon(int id)
        {
            InitializeComponent();

            maLuot = id;

            dgvThucDon.AutoGenerateColumns = false;
            dgvChiTietGoi.AutoGenerateColumns = false;

            nudSoLuong.DecimalPlaces = 0;
            txtGhiChu.MaxLength = 255;
            Load += (s, e) =>
            {
                if (!FormHelper.Run(() =>
                {
                    NghiepVuHelper.Quyen("GOI_MON");
                    var p = new PhucVuService();
                    var l = p.Luot(id);
                    lblThongTinBan.Text = "Bàn: " + p.TenBan(id);
                    lblHinhThuc.Text = "Hình thức: " + l.HinhThuc;
                    lblGoiBuffet.Text = l.MaGoi.HasValue ? "Mã gói: " + l.MaGoi : "";
                    if (l.HinhThuc == "COMBO")
                        FormHelper.Combo(cboLoaiChon, "COMBO", "Combo", "MON", "Món gọi thêm");
                    else
                        FormHelper.Combo(cboLoaiChon, "MON", "Món ăn / đồ uống");
                    dgvChiTietGoi.DataSource = draft;
                    Reload();
                    Total();
                }))
                    Close();
            };
            cboLoaiChon.SelectionChangeCommitted += (s, e) => FormHelper.Run(Reload);
            txtTimKiem.TextChanged += (s, e) =>
            {
                if (maLuot > 0 && cboLoaiChon.DataSource != null)
                    FormHelper.Run(Reload);
            };
            btnLamMoi.Click += (s, e) => FormHelper.Run(Reload);
            btnThem.Click += (s, e) => Add();
            btnXoaDong.Click += (s, e) =>
            {
                var d = FormHelper.Selected<DongGoiMonDTO>(dgvChiTietGoi);
                if (d != null)
                    draft.Remove(d);
                Total();
            };
            btnGuiPhieu.Click += (s, e) => Send();
            btnDong.Click += (s, e) => Close();
            FormClosing += (s, e) =>
            {
                if (saving)
                    e.Cancel = true;
                else if (draft.Count > 0 && !FormHelper.Confirm("Bỏ đợt gọi đang soạn và đóng?"))
                    e.Cancel = true;
            };
        }

        private void Reload()
        {
            dgvThucDon.DataSource = service.ThucDon(maLuot, FormHelper.Value(cboLoaiChon), txtTimKiem.Text);
        }

        private void Add()
        {
            FormHelper.Run(() =>
            {
                var x = FormHelper.Selected<ThucDonDTO>(dgvThucDon);
                if (x == null)
                    throw new ArgumentException("Chọn món hoặc combo.");
                int qty = (int)nudSoLuong.Value;
                var old = draft.FirstOrDefault(d => d.Ma == x.Ma && d.Loai == x.Loai);
                if (old != null)
                {
                    if (old.DonGia != x.DonGia)
                        throw new InvalidOperationException("Giá thay đổi. Xóa dòng cũ trước.");
                    if (old.SoLuong + qty > 1000)
                        throw new ArgumentException("Tối đa 1000 mỗi dòng.");
                    old.SoLuong += qty;
                    draft.ResetBindings();
                }
                else
                    draft.Add(new DongGoiMonDTO { Ma = x.Ma, Loai = x.Loai, Ten = x.Ten, SoLuong = qty, DonGia = x.DonGia });
                Total();
            });
        }

        private void Total()
        {
            lblTongTienDot.Text = "Tiền phát sinh: " + draft.Sum(x => x.ThanhTien).ToString("N0") + " đ";
            btnGuiPhieu.Enabled = draft.Count > 0 && !saving;
        }

        private void Send()
        {
            if (saving || draft.Count == 0 || !FormHelper.Confirm("Gửi phiếu và trừ kho nguyên liệu?"))
                return;
            saving = true;
            Total();
            int id = 0;
            bool ok = FormHelper.Run(() => id = service.Gui(new GoiMonDTO { MaLuot = maLuot, GhiChu = txtGhiChu.Text, ChiTiet = draft.ToList() }));
            saving = false;
            if (ok)
            {
                draft.Clear();
                txtGhiChu.Clear();
                MessageBox.Show("Đã gửi phiếu số " + id + ". Có thể tiếp tục gọi đợt mới.");
            }

            Total();
        }
    }
}
