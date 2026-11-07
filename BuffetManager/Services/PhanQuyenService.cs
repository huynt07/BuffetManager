using BuffetManager.Helpers;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class PhanQuyenService
    {
        // Mọi vai trò nhân viên được cấp bất kỳ chức năng nào
        public List<string> LayMaQuyenChoPhep(string maVaiTro)
        {
            if (string.IsNullOrWhiteSpace(maVaiTro))
            {
                throw new ArgumentException("Vai trò không hợp lệ.");
            }

            // Admin luôn toàn quyền, không được chỉnh sửa
            if (maVaiTro == "ADMIN")
            {
                throw new InvalidOperationException(
                    "Admin luôn toàn quyền, không được chỉnh sửa quyền.");
            }

            // Lấy toàn bộ mã chức năng có trong database
            return new ChucNangRepository()
                .LayDanhSach()
                .Select(cn => cn.MaCode)
                .ToList();
        }

        // Kiểm tra người thao tác và phạm vi quyền trước khi lưu
        public void LuuQuyen(string maVaiTro, List<string> cacMaQuyen)
        {
            // Người đang đăng nhập phải có quyền quản lý phân quyền
            if (!UserSession.CoQuyen("QUANLY_PHANQUYEN"))
            {
                throw new UnauthorizedAccessException(
                    "Bạn không có quyền quản lý phân quyền.");
            }

            if (string.IsNullOrWhiteSpace(maVaiTro))
            {
                throw new ArgumentException(
                    "Vui lòng chọn vai trò.");
            }

            if (cacMaQuyen == null)
            {
                throw new ArgumentException(
                    "Danh sách quyền không hợp lệ.");
            }

            // Hàm này cũng chặn sửa Admin và vai trò không hợp lệ
            var maChoPhep = LayMaQuyenChoPhep(maVaiTro);

            // Không cho cấp quyền ngoài phạm vi công việc
            if (cacMaQuyen.Any(ma => !maChoPhep.Contains(ma)))
            {
                throw new InvalidOperationException(
                    "Có chức năng không được phép cấp cho vai trò này.");
            }

            // Lưu quyền sau khi kiểm tra thành công
            var repository = new PhanQuyenRepository();
            repository.LuuQuyen(maVaiTro, cacMaQuyen);
        }
    }
}
