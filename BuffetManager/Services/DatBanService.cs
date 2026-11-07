using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class DatBanService
    {
        private readonly DatBanRepository datBanRepository =
    new DatBanRepository();

        // Kiểm tra dữ liệu trước khi chuyển sang Repository
        public int DatBan(
            int maBan,
            string hoTen,
            string sdt,
            DateTime gioDen,
            int soKhach)
        {
            // Kiểm tra quyền, không chỉ dựa vào nút trên giao diện
            if (!UserSession.CoQuyen("DAT_BAN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền đặt bàn.");
            }

            if (maBan <= 0)
            {
                throw new ArgumentException("Vui lòng chọn bàn.");
            }

            // Chỉ bỏ khoảng trắng ở hai đầu, giữ khoảng trắng giữa họ tên
            hoTen = (hoTen ?? "").Trim();
            sdt = (sdt ?? "").Trim();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException(
                    "Vui lòng nhập họ tên người đặt.");
            }

            // Giới hạn nhập liệu của ứng dụng
            if (hoTen.Length > 50)
            {
                throw new ArgumentException(
                    "Họ tên tối đa 50 ký tự.");
            }

            // Tạm quy định số điện thoại gồm 10–15 chữ số
            if (sdt.Length < 10 ||
                sdt.Length > 15 ||
                !sdt.All(c => c >= '0' && c <= '9'))
            {
                throw new ArgumentException(
                    "Số điện thoại phải gồm 10–15 chữ số, không chứa dấu cách.");
            }

            if (gioDen <= DateTime.Now)
            {
                throw new ArgumentException(
                    "Giờ đến phải sau thời điểm hiện tại.");
            }

            if (soKhach <= 0)
            {
                throw new ArgumentException(
                    "Số khách phải lớn hơn 0.");
            }

            // Mã người lập lấy từ tài khoản đang đăng nhập
            return datBanRepository.Them(
                maBan,
                UserSession.MaND,
                hoTen,
                sdt,
                gioDen,
                soKhach);
        }

        // Kiểm tra quyền trước khi hủy đặt bàn
        public void HuyDatBan(int maDatBan)
        {
            if (!UserSession.CoQuyen("DAT_BAN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền hủy đặt bàn.");
            }

            if (maDatBan <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn lượt đặt cần hủy.");
            }

            datBanRepository.Huy(maDatBan);
        }
    }
}
