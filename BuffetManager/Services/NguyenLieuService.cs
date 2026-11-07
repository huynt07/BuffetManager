using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class NguyenLieuService
    {
        // Kiểm tra dữ liệu trước khi thêm nguyên liệu
        public void Them(
            string tenNL,
            string donVi,
            string boPhan,
            decimal mucCanhBao)
        {
            // Kiểm tra quyền quản lý kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý kho.");
            }

            if (string.IsNullOrWhiteSpace(tenNL))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên nguyên liệu.");
            }

            if (string.IsNullOrWhiteSpace(donVi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập đơn vị.");
            }

            if (boPhan != "BEP" && boPhan != "PHACHE")
            {
                throw new ArgumentException(
                    "Vui lòng chọn bộ phận Bếp hoặc Pha chế.");
            }

            // Giới hạn giống NumericUpDown trên Form
            if (mucCanhBao < 0 || mucCanhBao > 1000000)
            {
                throw new ArgumentException(
                    "Mức cảnh báo phải từ 0 đến 1.000.000.");
            }

            // Phù hợp với độ chính xác của cột SQL
            if (mucCanhBao != decimal.Round(mucCanhBao, 3))
            {
                throw new ArgumentException(
                    "Mức cảnh báo chỉ được có tối đa 3 chữ số thập phân.");
            }

            // Bỏ khoảng trắng đầu và cuối
            tenNL = tenNL.Trim();
            donVi = donVi.Trim();

            var repository = new NguyenLieuRepository();

            repository.Them(
                tenNL, donVi, boPhan, mucCanhBao);
        }

        // Kiểm tra quyền và dữ liệu trước khi sửa nguyên liệu
        public void Sua(
            int maNL,
            string tenNL,
            string donVi,
            string boPhan,
            decimal mucCanhBao)
        {
            // Kiểm tra quyền quản lý kho
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý kho.");
            }

            if (maNL <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn nguyên liệu cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenNL))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên nguyên liệu.");
            }

            if (string.IsNullOrWhiteSpace(donVi))
            {
                throw new ArgumentException(
                    "Vui lòng nhập đơn vị.");
            }

            if (boPhan != "BEP" && boPhan != "PHACHE")
            {
                throw new ArgumentException(
                    "Vui lòng chọn bộ phận Bếp hoặc Pha chế.");
            }

            // Giới hạn giống khi thêm nguyên liệu
            if (mucCanhBao < 0 || mucCanhBao > 1000000)
            {
                throw new ArgumentException(
                    "Mức cảnh báo phải từ 0 đến 1.000.000.");
            }

            if (mucCanhBao != decimal.Round(mucCanhBao, 3))
            {
                throw new ArgumentException(
                    "Mức cảnh báo chỉ được có tối đa 3 chữ số thập phân.");
            }

            // Chuẩn hóa nội dung nhập
            tenNL = tenNL.Trim();
            donVi = donVi.Trim();

            // Repository kiểm tra ràng buộc và lưu thay đổi
            var repository = new NguyenLieuRepository();

            repository.Sua(
                maNL, tenNL, donVi, boPhan, mucCanhBao);
        }

        // Kiểm tra quyền và mã nguyên liệu trước khi xóa
        public void Xoa(int maNL)
        {
            // Chỉ người có quyền quản lý kho mới được xóa
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý kho.");
            }

            // Mã nguyên liệu phải hợp lệ
            if (maNL <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn nguyên liệu cần xóa.");
            }

            // Repository kiểm tra tồn kho và dữ liệu liên quan
            var repository = new NguyenLieuRepository();
            repository.Xoa(maNL);
        }
    }
}
