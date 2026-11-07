using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class GoiBuffetService
    {
        // Kiểm tra dữ liệu trước khi thêm gói buffet
        public void Them(
            string tenGoi,
            decimal giaNguoiLon,
            decimal donGiaPhatMoiKg,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (string.IsNullOrWhiteSpace(tenGoi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên gói buffet.");
            }

            // Giới hạn giống các NumericUpDown trên Form
            if (giaNguoiLon < 0 || giaNguoiLon > 100000000)
            {
                throw new ArgumentException(
                    "Giá vé phải từ 0 đến 100.000.000 đồng.");
            }

            if (donGiaPhatMoiKg < 0 ||
                donGiaPhatMoiKg > 100000000)
            {
                throw new ArgumentException(
                    "Tiền phạt phải từ 0 đến 100.000.000 đồng/kg.");
            }

            if (giaNguoiLon < 1000 || giaNguoiLon % 1000m != 0)
            {
                throw new ArgumentException(
                    "Giá Buffet phải từ 1.000đ và chia hết cho 1.000đ.");
            }

            // Chỉ chấp nhận số tiền nguyên đồng
            if (giaNguoiLon != decimal.Truncate(giaNguoiLon) ||
                donGiaPhatMoiKg != decimal.Truncate(donGiaPhatMoiKg))
            {
                throw new ArgumentException(
                    "Giá vé và tiền phạt phải là số nguyên đồng.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenGoi = tenGoi.Trim();

            var repository = new GoiBuffetRepository();

            repository.Them(
                tenGoi,
                giaNguoiLon,
                donGiaPhatMoiKg,
                dangBan);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa gói buffet
        public void Sua(
            int maGoi,
            string tenGoi,
            decimal giaNguoiLon,
            decimal donGiaPhatMoiKg,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maGoi <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn gói buffet cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenGoi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên gói buffet.");
            }

            // Kiểm tra giới hạn giá giống khi thêm gói
            if (giaNguoiLon < 0 || giaNguoiLon > 100000000)
            {
                throw new ArgumentException(
                    "Giá vé phải từ 0 đến 100.000.000 đồng.");
            }

            if (donGiaPhatMoiKg < 0 ||
                donGiaPhatMoiKg > 100000000)
            {
                throw new ArgumentException(
                    "Tiền phạt phải từ 0 đến 100.000.000 đồng/kg.");
            }

            if (giaNguoiLon < 1000 || giaNguoiLon % 1000m != 0)
            {
                throw new ArgumentException(
                    "Giá Buffet phải từ 1.000đ và chia hết cho 1.000đ.");
            }

            // Chỉ chấp nhận số tiền nguyên đồng
            if (giaNguoiLon != decimal.Truncate(giaNguoiLon) ||
                donGiaPhatMoiKg != decimal.Truncate(donGiaPhatMoiKg))
            {
                throw new ArgumentException(
                    "Giá vé và tiền phạt phải là số nguyên đồng.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenGoi = tenGoi.Trim();

            var repository = new GoiBuffetRepository();

            repository.Sua(
                maGoi,
                tenGoi,
                giaNguoiLon,
                donGiaPhatMoiKg,
                dangBan);
        }

        // Kiểm tra quyền và mã gói trước khi xóa
        public void Xoa(int maGoi)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã gói phải hợp lệ
            if (maGoi <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn gói buffet cần xóa.");
            }

            // Repository kiểm tra dữ liệu liên quan trước khi xóa
            var repository = new GoiBuffetRepository();
            repository.Xoa(maGoi);
        }
    }
}
