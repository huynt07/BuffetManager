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
    public partial class frmLichSuHoaDon : Form
    {
        private int page = 1, count;
        private const int pageSize = 20;
        private readonly HoaDonService service = new HoaDonService();
        private DateTime tu, den;
        private string mode = "";
        public frmLichSuHoaDon()
        {
            InitializeComponent();

            // Nhấp đúp dòng dữ liệu để xem/in hóa đơn.
            dgvHoaDon.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    MoBaoCaoHoaDon();
            };

            dgvHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            Load += (s, e) =>
            {
                if (!FormHelper.Run(() =>
                {
                    NghiepVuHelper.Quyen("XEM_BAOCAO");
                    dtpTuNgay.Value = DateTime.Today.AddDays(-30);
                    dtpDenNgay.Value = DateTime.Today;
                    FormHelper.Combo(cboHinhThuc, "", "Tất cả", "BUFFET", "Buffet", "COMBO", "Combo", "GOIMON", "Gọi món");
                    Search();
                }))
                    Close();
            };
            btnTimKiem.Click += (s, e) => FormHelper.Run(Search);
            btnTrangTruoc.Click += (s, e) =>
            {
                if (page > 1)
                {
                    page--;
                    FormHelper.Run(Reload);
                }
            };
            btnTrangSau.Click += (s, e) =>
            {
                if (page * pageSize < count)
                {
                    page++;
                    FormHelper.Run(Reload);
                }
            };
            dgvHoaDon.SelectionChanged += (s, e) => FormHelper.Run(Details);
            btnDong.Click += (s, e) => Close();
        }

        private void MoBaoCaoHoaDon()
        {
            FormHelper.Run(() =>
            {
                var hoaDon =
                    FormHelper.Selected<HoaDonDTO>(dgvHoaDon);

                if (hoaDon == null)
                {
                    MessageBox.Show("Hãy chọn một hóa đơn.");
                    return;
                }

                using (var form = new frmReportHoaDon(hoaDon.MaHD))
                {
                    form.ShowDialog(this);
                }
            });
        }

        private void Search()
        {
            page = 1;
            tu = dtpTuNgay.Value;
            den = dtpDenNgay.Value;
            mode = FormHelper.Value(cboHinhThuc);
            Reload();
        }

        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            FormHelper.Run(() =>
            {
                // Lấy điều kiện đang chọn trên màn hình.
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                string hinhThuc = FormHelper.Value(cboHinhThuc);

                using (var form = new frmReportDoanhThu(
                    tuNgay, denNgay, hinhThuc))
                {
                    form.ShowDialog(this);
                }
            }); 
        }

        private void Reload()
        {
            decimal total;
            var list = service.DanhSach(tu, den, mode, page, pageSize, out count, out total);
            dgvHoaDon.DataSource = list;
            lblTongDoanhThu.Text = "Tổng toàn bộ kết quả lọc: " + total.ToString("N0") + " đ";
            lblTrang.Text = "Trang " + page + " / " + Math.Max(1, (count + pageSize - 1) / pageSize) + " — " + count + " hóa đơn";
            btnTrangTruoc.Enabled = page > 1;
            btnTrangSau.Enabled = page * pageSize < count;
            Details();
        }

        private void Details()
        {
            var d = FormHelper.Selected<HoaDonDTO>(dgvHoaDon);
            dgvChiTietHoaDon.DataSource = d == null ? new List<ChiTietHoaDonDTO>() : service.ChiTiet(d.MaHD);
        }

    }
}
