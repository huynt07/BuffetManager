using BuffetManager.Helpers;
using BuffetManager.Reports;
using BuffetManager.Services;
using Microsoft.Reporting.WinForms;
using QRCoder;
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
    public partial class frmReportHoaDon : Form
    {
        private int maHD;

        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void frmReportHoaDon_Load(object sender, EventArgs e)
        {

            // this.reportViewer1.RefreshReport();
        }

        // Nhận mã hóa đơn từ màn hình thanh toán hoặc lịch sử.
        public frmReportHoaDon(int id) : this()
        {
            maHD = id;

            Load += (s, e) =>
            {
                if (!FormHelper.Run(TaiBaoCao))
                    Close();
            };
        }

        public frmReportHoaDon(int maLuot, bool xemTamTinh) : this()
        {
            if (!xemTamTinh || maLuot <= 0)
                throw new ArgumentException("Lượt phục vụ không hợp lệ.");

            Text = "Phiếu tạm tính - Chưa thanh toán";

            Load += (s, e) =>
            {
                if (!FormHelper.Run(() => TaiBaoCaoTamTinh(maLuot)))
                    Close();
            };
        }

        private void TaiBaoCao()
        {
            var duLieu = new BaoCaoService().HoaDon(maHD);
            var hoaDon = duLieu.HoaDon;

            reportViewer1.ProcessingMode = ProcessingMode.Local;

            var report = reportViewer1.LocalReport;

            // Đường dẫn resource: tên project + thư mục + tên báo cáo.
            report.ReportEmbeddedResource =
                "BuffetManager.Reports.rptHoaDon.rdlc";

            report.DataSources.Clear();

            // Tên này phải trùng Dataset trong Report Data của RDLC.
            report.DataSources.Add(
                new ReportDataSource(
                    "dsChiTietHoaDon",
                    duLieu.ChiTiet));

            // Truyền thông tin cho 4 Parameter đã tạo.
            report.SetParameters(new[]
            {
        new ReportParameter(
            "pMaHD", hoaDon.MaHD.ToString()),

        new ReportParameter(
            "pNgayLap",
            hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm")),

        new ReportParameter(
            "pBan", hoaDon.TenBanSnapshot),

        new ReportParameter(
            "pHinhThuc",
            BaoCaoService.TenHinhThuc(hoaDon.HinhThuc)),

        new ReportParameter("pQR", TaoQRBase64("HD" + hoaDon.MaHD))
    });

            reportViewer1.RefreshReport();
        }

        private void TaiBaoCaoTamTinh(int maLuot)
        {
            var phucVu = new PhucVuService();
            var luot = phucVu.Luot(maLuot);

            // Lấy chi tiết các vé, combo, món đã gọi.
            // Chưa tính tiền phạt đồ ăn thừa.
            var chiTiet = new ThanhToanService().DuTinh(maLuot, 0m);

            if (chiTiet.Count == 0)
                throw new InvalidOperationException(
                    "Bàn chưa có món hoặc gói cần thanh toán.");

            // Chuyển dữ liệu sang DataTable của báo cáo.
            var bang = new dsHoaDon.dtChiTietHoaDonDataTable();

            foreach (var dong in chiTiet)
            {
                bang.Rows.Add(
                    dong.LoaiDong,
                    dong.TenDong,
                    dong.DonVi,
                    dong.SoLuong,
                    dong.DonGia,
                    dong.ThanhTien
                );
            }

            reportViewer1.ProcessingMode = ProcessingMode.Local;

            var report = reportViewer1.LocalReport;

            report.ReportEmbeddedResource =
                "BuffetManager.Reports.rptHoaDon.rdlc";

            report.DataSources.Clear();

            report.DataSources.Add(
    new ReportDataSource(
        "dsChiTietHoaDon",
        (System.Data.DataTable)bang));

            report.SetParameters(new[]
            {
        new ReportParameter("pMaHD", "TẠM TÍNH"),

        new ReportParameter(
            "pNgayLap",
            DateTime.Now.ToString("dd/MM/yyyy HH:mm")),

        new ReportParameter(
            "pBan",
            phucVu.TenBan(maLuot)),

        new ReportParameter(
            "pHinhThuc",
            BaoCaoService.TenHinhThuc(luot.HinhThuc)),

        new ReportParameter(
            "pQR", 
            TaoQRBase64("Ban " + phucVu.TenBan(maLuot) + " - " + chiTiet.Sum(x => x.ThanhTien).ToString("0")))
    });

            reportViewer1.RefreshReport();
        }

        private static string TaoQRBase64(string text)
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.M))
            using (var qr = new QRCode(data))
            using (var bmp = qr.GetGraphic(8))
            using (var ms = new System.IO.MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
