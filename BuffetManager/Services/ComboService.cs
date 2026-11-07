using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class ComboService
    {
        // Kiểm tra dữ liệu trước khi thêm combo
        public void Them(
            string tenCombo,
            int soNguoiGoiY,
            decimal giaCombo,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (string.IsNullOrWhiteSpace(tenCombo))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên combo.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (soNguoiGoiY < 1 || soNguoiGoiY > 100)
            {
                throw new ArgumentException(
                    "Số người gợi ý phải từ 1 đến 100.");
            }

            if (giaCombo < 0 || giaCombo > 100000000)
            {
                throw new ArgumentException(
                    "Giá combo phải từ 0 đến 100.000.000 đồng.");
            }

            if (giaCombo < 1000 || giaCombo % 1000m != 0)
            {
                throw new ArgumentException(
                    "Giá Combo phải từ 1.000đ và chia hết cho 1.000đ.");
            }

            // Chỉ chấp nhận giá nguyên đồng
            if (giaCombo != decimal.Truncate(giaCombo))
            {
                throw new ArgumentException(
                    "Giá combo phải là số nguyên đồng.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenCombo = tenCombo.Trim();

            var repository = new ComboRepository();

            repository.Them(
                tenCombo,
                soNguoiGoiY,
                giaCombo,
                dangBan);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa combo
        public void Sua(
            int maCombo,
            string tenCombo,
            int soNguoiGoiY,
            decimal giaCombo,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maCombo <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn combo cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenCombo))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên combo.");
            }

            // Giới hạn giống khi thêm combo
            if (soNguoiGoiY < 1 || soNguoiGoiY > 100)
            {
                throw new ArgumentException(
                    "Số người gợi ý phải từ 1 đến 100.");
            }

            if (giaCombo < 0 || giaCombo > 100000000)
            {
                throw new ArgumentException(
                    "Giá combo phải từ 0 đến 100.000.000 đồng.");
            }

            if (giaCombo < 1000 || giaCombo % 1000m != 0)
            {
                throw new ArgumentException(
                    "Giá Combo phải từ 1.000đ và chia hết cho 1.000đ.");
            }

            // Chỉ chấp nhận giá nguyên đồng
            if (giaCombo != decimal.Truncate(giaCombo))
            {
                throw new ArgumentException(
                    "Giá combo phải là số nguyên đồng.");
            }

            // Bỏ khoảng trắng đầu và cuối tên
            tenCombo = tenCombo.Trim();

            var repository = new ComboRepository();

            repository.Sua(
                maCombo,
                tenCombo,
                soNguoiGoiY,
                giaCombo,
                dangBan);
        }

        // Kiểm tra quyền và mã combo trước khi xóa
        public void Xoa(int maCombo)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã combo phải hợp lệ
            if (maCombo <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn combo cần xóa.");
            }

            // Repository kiểm tra dữ liệu liên quan trước khi xóa
            var repository = new ComboRepository();
            repository.Xoa(maCombo);
        }
    }
}
