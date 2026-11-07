using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class BaoCaoService
    {
        public BaoCaoHoaDonDTO HoaDon(int maHD)
        {
            // Có ít nhất một trong các quyền này mới được xem/in.
            NghiepVuHelper.Quyen(
                "XEM_BAOCAO",
                "THANH_TOAN",
                "LAP_HOADON");

            if (maHD <= 0)
                throw new ArgumentException(
                    "Mã hóa đơn không hợp lệ.");

            return new BaoCaoRepository().HoaDon(maHD);
        }

        // Đổi mã lưu trong database thành tên hiển thị.
        public static string TenHinhThuc(string ma)
        {
            switch (ma)
            {
                case "BUFFET":
                    return "Buffet";

                case "COMBO":
                    return "Combo";

                case "GOIMON":
                    return "Gọi món";

                default:
                    return "Không xác định";
            }
        }

        public BaoCaoDoanhThuDTO DoanhThu(
    DateTime tuNgay, DateTime denNgay, string hinhThuc)
        {
            // Chỉ người có quyền báo cáo mới được xem doanh thu.
            NghiepVuHelper.Quyen("XEM_BAOCAO");

            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException(
                    "Từ ngày không được lớn hơn đến ngày.");
            }

            // Repository cần cộng thêm 1 ngày khi lọc.
            if (denNgay.Date == DateTime.MaxValue.Date)
            {
                throw new ArgumentException(
                    "Ngày kết thúc không hợp lệ.");
            }

            // Chuỗi rỗng tương ứng lựa chọn Tất cả.
            hinhThuc = (hinhThuc ?? "").Trim().ToUpperInvariant();

            if (hinhThuc != "" &&
                hinhThuc != "BUFFET" &&
                hinhThuc != "COMBO" &&
                hinhThuc != "GOIMON")
            {
                throw new ArgumentException(
                    "Hình thức dùng bữa không hợp lệ.");
            }

            return new BaoCaoRepository()
                .DoanhThu(tuNgay, denNgay, hinhThuc);
        }
    }
}
