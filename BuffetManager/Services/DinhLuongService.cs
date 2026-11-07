using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class DinhLuongService
    {
        // Kiểm tra dữ liệu trước khi thêm định lượng
        public void Them(int maMon, int maNL, decimal luongCan)
        {
            // Kiểm tra quyền quản lý kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý định lượng.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món ăn.");
            }

            if (maNL <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn nguyên liệu.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (luongCan < 0.001m || luongCan > 1000000m)
            {
                throw new ArgumentException(
                    "Lượng cần phải từ 0,001 đến 1.000.000.");
            }

            // Phù hợp độ chính xác của cột SQL
            if (luongCan != decimal.Round(luongCan, 3))
            {
                throw new ArgumentException(
                    "Lượng cần chỉ được có tối đa 3 chữ số thập phân.");
            }

            // Repository kiểm tra bộ phận, trùng nguyên liệu và lưu
            var repository = new DinhLuongRepository();
            repository.Them(maMon, maNL, luongCan);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa lượng nguyên liệu
        public void Sua(int maMon, int maNL, decimal luongCan)
        {
            // Kiểm tra quyền quản lý kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý định lượng.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món ăn.");
            }

            if (maNL <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn nguyên liệu cần sửa.");
            }

            // Giới hạn giống khi thêm định lượng
            if (luongCan < 0.001m || luongCan > 1000000m)
            {
                throw new ArgumentException(
                    "Lượng cần phải từ 0,001 đến 1.000.000.");
            }

            if (luongCan != decimal.Round(luongCan, 3))
            {
                throw new ArgumentException(
                    "Lượng cần chỉ được có tối đa 3 chữ số thập phân.");
            }

            // Repository kiểm tra dòng định lượng tồn tại và lưu
            var repository = new DinhLuongRepository();
            repository.Sua(maMon, maNL, luongCan);
        }

        // Kiểm tra quyền trước khi gỡ nguyên liệu khỏi công thức
        public void Xoa(int maMon, int maNL)
        {
            // Kiểm tra quyền quản lý kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý định lượng.");
            }

            if (maMon <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn món ăn.");
            }

            if (maNL <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn nguyên liệu cần gỡ.");
            }

            // Repository kiểm tra dòng định lượng và xóa liên kết
            var repository = new DinhLuongRepository();
            repository.Xoa(maMon, maNL);
        }
    }
}
