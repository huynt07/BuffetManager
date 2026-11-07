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
    public class NhapKhoService
    {
        // Kiểm tra phiếu và trả về mã phiếu sau khi lưu
        public int LuuPhieu(string nhaCungCap, string ghiChu, List<ChiTietNhapDTO> chiTiet)
        {
            // Kiểm tra quyền và phiên đăng nhập
            if (!UserSession.CoQuyen("QUANLY_KHO"))
            {
                throw new UnauthorizedAccessException("Bạn không có quyền nhập kho.");
            }

            // Phiếu phải có ít nhất một nguyên liệu
            if (chiTiet == null || chiTiet.Count == 0)
            {
                throw new ArgumentException("Phiếu nhập phải có ít nhất một nguyên liệu.");
            }

            // Kiểm tra từng dòng trước khi thực hiện transaction
            foreach (var dong in chiTiet)
            {
                if (dong == null || dong.MaNL <= 0)
                {
                    throw new ArgumentException("Có dòng nguyên liệu không hợp lệ.");
                }

                if (string.IsNullOrWhiteSpace(dong.DonVi))
                {
                    throw new ArgumentException("Nguyên liệu chưa có đơn vị.");
                }

                if (dong.SoLuong < 0.001m || dong.SoLuong > 1000000m || dong.SoLuong != decimal.Round(dong.SoLuong, 3))
                {
                    throw new ArgumentException("Số lượng phải từ 0,001 đến 1.000.000 " + "và có tối đa 3 chữ số thập phân.");
                }

                if (dong.DonGia < 0 || dong.DonGia > 100000000m || dong.DonGia != decimal.Truncate(dong.DonGia))
                {
                    throw new ArgumentException("Đơn giá phải là số nguyên từ 0 " + "đến 100.000.000 đồng.");
                }
            }

            // Mỗi nguyên liệu chỉ xuất hiện một lần trong phiếu
            bool trungNguyenLieu = chiTiet.GroupBy(dong => dong.MaNL).Any(nhom => nhom.Count() > 1);
            if (trungNguyenLieu)
            {
                throw new ArgumentException("Phiếu có nguyên liệu bị trùng.");
            }

            // Hai thông tin này không bắt buộc trong schema hiện tại
            nhaCungCap = string.IsNullOrWhiteSpace(nhaCungCap) ? null : nhaCungCap.Trim();
            ghiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim();
            if (nhaCungCap != null && nhaCungCap.Length > 150)
                throw new ArgumentException("Tên nhà cung cấp tối đa 150 ký tự.");
            if (ghiChu != null && ghiChu.Length > 255)
                throw new ArgumentException("Ghi chú tối đa 255 ký tự.");
            // Lấy người lập từ session, không cho nhập tùy ý
            var repository = new NhapKhoRepository();
            return repository.LuuPhieu(UserSession.MaND, nhaCungCap, ghiChu, chiTiet);
        }
    }
}
