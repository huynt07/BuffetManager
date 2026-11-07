using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class BaoCaoRepository
    {
        public BaoCaoHoaDonDTO HoaDon(int maHD)
        {
            using (var db = DbFactory.Create())
            {
                // Lấy thông tin chung của hóa đơn.
                var hoaDon = db.HOADONs
                    .SingleOrDefault(x => x.MaHD == maHD);

                if (hoaDon == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy hóa đơn.");

                // Tạo bảng theo cấu trúc dsHoaDon.xsd đã thiết kế.
                var bang = new dsHoaDon.dtChiTietHoaDonDataTable();

                // Lấy chi tiết đã chốt lúc thanh toán.
                var chiTiet = db.CHITIETHOADONs
                    .Where(x => x.MaHD == maHD)
                    .OrderBy(x => x.MaCTHD)
                    .ToList();

                foreach (var dong in chiTiet)
                {
                    decimal thanhTien = dong.ThanhTien
                        ?? Math.Round(
                            dong.SoLuong * dong.DonGia,
                            2,
                            MidpointRounding.AwayFromZero);

                    bang.Rows.Add(
                        dong.LoaiDong,
                        dong.TenDong,
                        dong.DonVi,
                        dong.SoLuong,
                        dong.DonGia,
                        thanhTien);
                }

                return new BaoCaoHoaDonDTO
                {
                    HoaDon = hoaDon,
                    ChiTiet = bang
                };
            }
        }

        public BaoCaoDoanhThuDTO DoanhThu(
    DateTime tuNgay, DateTime denNgay, string hinhThuc)
        {
            DateTime tu = tuNgay.Date;

            // Lấy hết ngày kết thúc bằng điều kiện nhỏ hơn ngày tiếp theo.
            DateTime den = denNgay.Date.AddDays(1);

            using (var db = DbFactory.Create())
            {
                var query = db.HOADONs
                    .Where(x => x.NgayLap >= tu && x.NgayLap < den);

                // Chuỗi rỗng nghĩa là lấy tất cả hình thức.
                if (!string.IsNullOrWhiteSpace(hinhThuc))
                {
                    query = query.Where(x => x.HinhThuc == hinhThuc);
                }

                // Lấy toàn bộ kết quả để in, không phân trang như màn hình.
                var danhSach = query
                    .OrderBy(x => x.NgayLap)
                    .ThenBy(x => x.MaHD)
                    .Select(x => new
                    {
                        x.MaHD,
                        x.NgayLap,
                        TenBan = x.TenBanSnapshot,
                        x.HinhThuc,
                        x.PhuongThuc,
                        x.TongTien
                    })
                    .ToList();

                var bang = new dsDoanhThu.dtDoanhThuDataTable();

                foreach (var hd in danhSach)
                {
                    // Gán theo tên cột để không phụ thuộc thứ tự trong XSD.
                    var dong = bang.NewdtDoanhThuRow();

                    dong.MaHD = hd.MaHD;
                    dong.NgayLap = hd.NgayLap;
                    dong.TenBan = hd.TenBan;
                    dong.HinhThuc = hd.HinhThuc;
                    dong.PhuongThuc = hd.PhuongThuc;
                    dong.TongTien = hd.TongTien;

                    bang.AdddtDoanhThuRow(dong);
                }

                return new BaoCaoDoanhThuDTO
                {
                    TuNgay = tu,
                    DenNgay = denNgay.Date,
                    HinhThuc = hinhThuc,
                    DanhSach = bang,

                    // Sum trên danh sách rỗng trả về 0.
                    TongDoanhThu = danhSach.Sum(x => x.TongTien)
                };
            }
        }
    }
}
