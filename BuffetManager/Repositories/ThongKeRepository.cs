using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class ThongKeRepository
    {
        public List<DoanhThuThangDTO> DoanhThuTheoNam(int nam)
        {
            // Giới hạn giống ô chọn năm trên giao diện.
            if (nam < 2000 || nam > 2100)
                throw new ArgumentException("Năm phải từ 2000 đến 2100.");

            DateTime tuNgay = new DateTime(nam, 1, 1);
            DateTime denNgay = tuNgay.AddYears(1);

            using (var db = DbFactory.Create())
            {
                // Lọc hóa đơn trong năm, nhóm theo tháng và cộng doanh thu.
                var duLieu = db.HOADONs
                    .Where(h => h.NgayLap >= tuNgay
                             && h.NgayLap < denNgay)
                    .GroupBy(h => h.NgayLap.Month)
                    .Select(g => new DoanhThuThangDTO
                    {
                        Thang = g.Key,
                        DoanhThu = g.Sum(h => h.TongTien)
                    })
                    .ToList();

                // Đảm bảo luôn có đủ 12 tháng.
                var ketQua = new List<DoanhThuThangDTO>();

                for (int thang = 1; thang <= 12; thang++)
                {
                    var item = duLieu.FirstOrDefault(
                        x => x.Thang == thang);

                    ketQua.Add(new DoanhThuThangDTO
                    {
                        Thang = thang,
                        DoanhThu = item == null ? 0m : item.DoanhThu
                    });
                }

                return ketQua;
            }
        }

        public List<DoanhThuHinhThucDTO> DoanhThuTheoHinhThuc(
    int thang, int nam)
        {
            if (thang < 1 || thang > 12)
                throw new ArgumentException("Tháng phải từ 1 đến 12.");

            if (nam < 2000 || nam > 2100)
                throw new ArgumentException("Năm phải từ 2000 đến 2100.");

            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            using (var db = DbFactory.Create())
            {
                // Nhóm hóa đơn theo Buffet, Combo, Gọi món.
                // Dùng query syntax để bổ sung kỹ thuật LINQ của đồ án.
                var query =
                    from h in db.HOADONs
                    where h.NgayLap >= tuNgay
                       && h.NgayLap < denNgay
                    group h by h.HinhThuc into nhom
                    orderby nhom.Key
                    select new DoanhThuHinhThucDTO
                    {
                        HinhThuc = nhom.Key,
                        DoanhThu = nhom.Sum(h => h.TongTien)
                    };

                return query.ToList();
            }
        }

        public List<TopMonDTO> Top5MonTrongThang(int thang, int nam)
        {
            if (thang < 1 || thang > 12)
                throw new ArgumentException("Tháng phải từ 1 đến 12.");

            if (nam < 2000 || nam > 2100)
                throw new ArgumentException("Năm phải từ 2000 đến 2100.");

            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            using (var db = DbFactory.Create())
            {
                // Các lượt đã có hóa đơn trong tháng.
                // Distinct tránh nhân đôi số lượng khi nối dữ liệu.
                var luotDaThanhToan = db.HOADONs
                    .Where(h => h.NgayLap >= tuNgay
                             && h.NgayLap < denNgay)
                    .Select(h => h.MaLuot)
                    .Distinct();

                // Lấy món thuộc lượt đã thanh toán, bỏ món hủy.
                var query =
                    from ct in db.CHITIETGOIMONs
                    join luot in luotDaThanhToan
                        on ct.MaLuot equals luot
                    join mon in db.MONANs
                        on ct.MaMon equals mon.MaMon
                    where ct.TrangThai != "HUY"
                    group ct by new
                    {
                        mon.MaMon,
                        mon.TenMon
                    }
                    into nhom
                    select new TopMonDTO
                    {
                        MaMon = nhom.Key.MaMon,
                        TenMon = nhom.Key.TenMon,
                        SoLuong = nhom.Sum(x => x.SoLuong)
                    };

                // Lấy tối đa 5 món có tổng số lượng cao nhất.
                return query
                    .OrderByDescending(x => x.SoLuong)
                    .ThenBy(x => x.MaMon)
                    .Take(5)
                    .ToList();
            }
        }
    }
}
