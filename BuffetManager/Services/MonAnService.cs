using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class MonAnService
    {
        // Kiểm tra quyền và dữ liệu trước khi thêm món
        public void Them(
            string tenMon,
            int maDM,
            string donVi,
            decimal giaLe,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên món.");
            }

            if (maDM <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn danh mục.");
            }

            if (string.IsNullOrWhiteSpace(donVi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập đơn vị, ví dụ: phần, đĩa, ly.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (giaLe < 0 || giaLe > 100000000)
            {
                throw new ArgumentException(
                    "Giá lẻ phải từ 0 đến 100.000.000 đồng.");
            }

            // Chỉ chấp nhận giá nguyên đồng
            if (giaLe != decimal.Truncate(giaLe))
            {
                throw new ArgumentException(
                    "Giá lẻ phải là số nguyên đồng.");
            }

            // Bỏ khoảng trắng đầu và cuối
            tenMon = tenMon.Trim();
            donVi = donVi.Trim();

            var repository = new MonAnRepository();

            repository.Them(
                tenMon, maDM, donVi, giaLe, dangBan);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa món
        public void Sua(
            int maMon,
            string tenMon,
            int maDM,
            string donVi,
            decimal giaLe,
            bool dangBan)
        {
            // Kiểm tra quyền quản lý danh mục
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên món.");
            }

            if (maDM <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn danh mục.");
            }

            if (string.IsNullOrWhiteSpace(donVi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập đơn vị.");
            }

            // Kiểm tra giới hạn giá giống khi thêm món
            if (giaLe < 0 || giaLe > 100000000)
            {
                throw new ArgumentException(
                    "Giá lẻ phải từ 0 đến 100.000.000 đồng.");
            }

            if (giaLe != decimal.Truncate(giaLe))
            {
                throw new ArgumentException(
                    "Giá lẻ phải là số nguyên đồng.");
            }

            // Chuẩn hóa tên món và đơn vị
            tenMon = tenMon.Trim();
            donVi = donVi.Trim();

            // Repository kiểm tra ràng buộc và lưu thay đổi
            var repository = new MonAnRepository();

            repository.Sua(
                maMon, tenMon, maDM, donVi, giaLe, dangBan);
        }

        // Kiểm tra quyền và mã món trước khi xóa
        public void Xoa(int maMon)
        {
            // Chỉ người có quyền quản lý danh mục mới được xóa
            if (!UserSession.CoQuyen("QUANLY_DANHMUC"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý danh mục.");
            }

            // Mã món phải hợp lệ
            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món cần xóa.");
            }

            // Repository kiểm tra các dữ liệu liên quan trước khi xóa
            var repository = new MonAnRepository();
            repository.Xoa(maMon);
        }
    }
}
