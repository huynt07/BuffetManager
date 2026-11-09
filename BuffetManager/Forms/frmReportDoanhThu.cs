using BuffetManager.Helpers;
using BuffetManager.Services;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReportDoanhThu : Form
    {
        private DateTime tuNgay;
        private DateTime denNgay;
        private string hinhThuc;

        public frmReportDoanhThu()
        {
            InitializeComponent();
        }

        public frmReportDoanhThu(
    DateTime tu, DateTime den, string mode) : this()
        {
            tuNgay = tu;
            denNgay = den;
            hinhThuc = mode;

            Load += (s, e) =>
            {
                if (!FormHelper.Run(TaiBaoCao))
                    Close();
            };
        }

        private void TaiBaoCao()
        {
            // Service kiểm tra quyền, ngày và lấy dữ liệu.
            var duLieu = new BaoCaoService()
                .DoanhThu(tuNgay, denNgay, hinhThuc);

            reportViewer1.ProcessingMode = ProcessingMode.Local;

            var report = reportViewer1.LocalReport;

            // Mẫu báo cáo đã chọn trong Designer.
            report.ReportEmbeddedResource =
                "BuffetManager.Reports.rptDoanhThu.rdlc";

            // Thay nguồn dữ liệu Designer bằng kết quả lọc thực tế.
            report.DataSources.Clear();
            report.DataSources.Add(
                new ReportDataSource("dsDoanhThu", duLieu.DanhSach));

            string tenHinhThuc =
                string.IsNullOrEmpty(duLieu.HinhThuc)
                ? "Tất cả"
                : BaoCaoService.TenHinhThuc(duLieu.HinhThuc);

            report.SetParameters(new[]
            {
        new ReportParameter(
            "pTuNgay", duLieu.TuNgay.ToString("dd/MM/yyyy")),

        new ReportParameter(
            "pDenNgay", duLieu.DenNgay.ToString("dd/MM/yyyy")),

        new ReportParameter("pHinhThuc", tenHinhThuc)
    });

            // Chỉ hiển thị sau khi đã truyền đủ dữ liệu và Parameter.
            reportViewer1.RefreshReport();
        }
    }
}
