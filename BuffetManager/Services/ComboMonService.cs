using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class ComboMonService
    {
        // Kiểm tra dữ liệu trước khi thêm món vào combo
        public void Them(int maCombo, int maMon, int soLuong)
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
                    "Vui lòng chọn combo.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món ăn.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (soLuong < 1 || soLuong > 1000)
            {
                throw new ArgumentException(
                    "Số lượng phải từ 1 đến 1000.");
            }

            // Repository kiểm tra ràng buộc và lưu liên kết
            var repository = new ComboMonRepository();
            repository.Them(maCombo, maMon, soLuong);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa số lượng món
        public void Sua(int maCombo, int maMon, int soLuong)
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
                    "Vui lòng chọn combo.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món cần sửa.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (soLuong < 1 || soLuong > 1000)
            {
                throw new ArgumentException(
                    "Số lượng phải từ 1 đến 1000.");
            }

            // Repository kiểm tra liên kết và lượt sử dụng trước khi lưu
            var repository = new ComboMonRepository();
            repository.Sua(maCombo, maMon, soLuong);
        }

        // Kiểm tra quyền và mã trước khi gỡ món khỏi combo
        public void Xoa(int maCombo, int maMon)
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
                    "Vui lòng chọn combo.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món cần gỡ.");
            }

            // Repository kiểm tra liên kết và lượt sử dụng trước khi xóa
            var repository = new ComboMonRepository();
            repository.Xoa(maCombo, maMon);
        }
    }
}
