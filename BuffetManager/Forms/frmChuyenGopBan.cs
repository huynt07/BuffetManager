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
    public partial class frmChuyenGopBan : Form
    {
        private int maBan, maLuot;
        public frmChuyenGopBan() : this(0, 0)
        {
        }

        public frmChuyenGopBan(int ban, int luot)
        {
            InitializeComponent();
            maBan = ban;
            maLuot = luot;
            Load += (s, e) =>
            {
                if (!FormHelper.Run(() =>
                {
                    NghiepVuHelper.Quyen("CHUYEN_GOP_BAN");
                    var p = new PhucVuService();
                    var l = p.Luot(luot);
                    lblBanNguon.Text = "Bàn nguồn: " + p.DanhSach().Single(x => x.MaBan == ban).TenBan;
                    lblHinhThucNguon.Text = "Hình thức: " + l.HinhThuc;
                    FormHelper.Combo(cboThaoTac, "CHUYEN", "Chuyển bàn", "GOP", "Gộp nhóm bàn / hóa đơn");
                    Reload();
                }))
                    Close();
            };
            cboThaoTac.SelectionChangeCommitted += (s, e) => FormHelper.Run(Reload);
            cboBanDich.SelectionChangeCommitted += (s, e) => Info();
            btnDong.Click += (s, e) => Close();
            btnThucHien.Click += (s, e) =>
            {
                if (!FormHelper.Confirm(FormHelper.Value(cboThaoTac) == "GOP" ? "Gộp hóa đơn; khách vẫn sử dụng cả hai nhóm bàn?" : "Chuyển bàn đã chọn?"))
                    return;
                if (FormHelper.Run(() =>
                {
                    var d = cboBanDich.SelectedItem as BanPhucVuDTO;
                    if (d == null)
                        throw new ArgumentException("Chọn bàn đích.");
                    new ChuyenGopBanService().ThucHien(new ChuyenGopBanDTO { MaBanNguon = maBan, MaLuotNguon = maLuot, MaBanDich = d.MaBan, ThaoTac = FormHelper.Value(cboThaoTac) });
                }))
                {
                    MessageBox.Show("Đã thực hiện.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
        }

        private void Reload()
        {
            var ds = new PhucVuService().DanhSach();
            bool move = FormHelper.Value(cboThaoTac) == "CHUYEN";
            cboBanDich.DisplayMember = "HienThi";
            cboBanDich.ValueMember = "MaBan";
            cboBanDich.DataSource = ds.Where(x => x.MaBan != maBan && (move ? x.TrangThai == "Trống" : x.MaLuot.HasValue && x.MaLuot != maLuot)).ToList();
            cboBanDich.SelectedIndex = -1;
            Info();
        }

        private void Info()
        {
            var d = cboBanDich.SelectedItem as BanPhucVuDTO;
            lblThongTinBanDich.Text = d == null ? "Thông tin bàn đích: —" : d.SoCho + " chỗ — " + d.HinhThuc;
        }

    }
}
