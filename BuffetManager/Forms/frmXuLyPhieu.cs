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
    public partial class frmXuLyPhieu : Form
    {
        private string dept;
        private readonly XuLyPhieuService service = new XuLyPhieuService();
        public frmXuLyPhieu() : this("BEP")
        {
        }

        public frmXuLyPhieu(string boPhan)
        {
            InitializeComponent();

            dept = boPhan;

            dgvChiTietPhieu.AutoGenerateColumns = false;

            Load += (s, e) =>
            {
                if (!FormHelper.Run(() =>
                {
                    lblBoPhan.Text = dept == "BEP" ? "Phiếu món bếp" : "Phiếu đồ uống";
                    FormHelper.Combo(cboTrangThai, "", "Tất cả món của lượt đang mở", "CHO", "Chờ làm", "DANG_LAM", "Đang làm", "DA_XONG", "Đã xong", "DA_PHUC_VU", "Đã phục vụ", "HUY", "Đã hủy");
                    Reload();
                }))
                    Close();
            };
            cboTrangThai.SelectionChangeCommitted += (s, e) => FormHelper.Run(Reload);
            btnLamMoi.Click += (s, e) => FormHelper.Run(Reload);
            dgvChiTietPhieu.SelectionChanged += (s, e) => Selection();
            btnBatDau.Click += (s, e) => Change("DANG_LAM");
            btnHoanThanh.Click += (s, e) => Change("DA_XONG");
            btnDaPhucVu.Click += (s, e) => Change("DA_PHUC_VU");
            btnHuyMon.Click += (s, e) => Change("HUY");
            btnDong.Click += (s, e) => Close();
        }

        private void Reload()
        {
            dgvChiTietPhieu.DataSource = service.DanhSach(dept, FormHelper.Value(cboTrangThai));
            
            // Cập nhật thông tin món đang chọn
            Selection();
        }

        private void Selection()
        {
            var d = FormHelper.Selected<ChiTietPhieuDTO>(dgvChiTietPhieu);
            bool cook = UserSession.CoQuyen(dept == "BEP" ? "XULY_MON_BEP" : "XULY_DO_UONG"), serve = UserSession.CoQuyen("GOI_MON");
            lblMonDangChon.Text = "Món: " + (d == null ? "—" : d.TenMon);
            lblGhiChu.Text = "Ghi chú: " + (d == null ? "" : d.GhiChu);
            btnBatDau.Enabled = d != null && d.TrangThai == "CHO" && cook;
            btnHoanThanh.Enabled = d != null && d.TrangThai == "DANG_LAM" && cook;
            btnDaPhucVu.Enabled = d != null && d.TrangThai == "DA_XONG" && serve;
            btnHuyMon.Enabled = d != null && d.TrangThai == "CHO" && (serve || cook) && (!d.MaChonCombo.HasValue || serve);
        }

        private void Change(string action)
        {
            var d = FormHelper.Selected<ChiTietPhieuDTO>(dgvChiTietPhieu);
            if (d == null)
                return;
            if (action == "HUY" && !FormHelper.Confirm(d.MaChonCombo.HasValue ? "Hủy TOÀN BỘ lần chọn combo này (tất cả số combo trong dòng) và hoàn kho? Chỉ được hủy khi mọi món còn chờ." : "Hủy dòng món chưa làm và hoàn kho?"))
                return;
            if (FormHelper.Run(() => service.CapNhat(d.MaCTG, dept, action)))
                FormHelper.Run(Reload);
        }
    }
}
