using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuffetManager.Repositories
{
    public class NhapKhoRepository
    {
        // Lưu phiếu và trả về mã phiếu vừa tạo
        public int LuuPhieu(
            int maND,
            string nhaCungCap,
            string ghiChu,
            List<ChiTietNhapDTO> chiTiet)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                DateTime ngayNhap = DateTime.Now;

                // Tạo phần thông tin chung của phiếu
                var phieu = new PHIEUNHAP
                {
                    MaND = maND,
                    NgayNhap = ngayNhap,
                    TenNhaCungCap = nhaCungCap,
                    GhiChu = ghiChu
                };

                db.GetTable<PHIEUNHAP>().InsertOnSubmit(phieu);

                // Lưu để lấy MaPN do SQL Server sinh
                db.SubmitChanges();

                // Xử lý theo thứ tự mã để giảm nguy cơ deadlock
                foreach (var dong in chiTiet.OrderBy(ct => ct.MaNL))
                {
                    var nguyenLieu = db.GetTable<NGUYENLIEU>()
                        .SingleOrDefault(nl => nl.MaNL == dong.MaNL);

                    if (nguyenLieu == null)
                    {
                        throw new InvalidOperationException(
                            "Nguyên liệu mã " + dong.MaNL
                            + " không còn tồn tại.");
                    }

                    // Không nhập theo đơn vị cũ nếu danh mục đã thay đổi
                    if (nguyenLieu.DonVi != dong.DonVi)
                    {
                        throw new InvalidOperationException(
                            "Đơn vị của nguyên liệu "
                            + nguyenLieu.TenNL
                            + " đã thay đổi. Vui lòng lập lại phiếu.");
                    }

                    // Lưu chi tiết nhập
                    var ctNhap = new CHITIETPHIEUNHAP
                    {
                        MaPN = phieu.MaPN,
                        MaNL = dong.MaNL,
                        SoLuong = dong.SoLuong,
                        DonGia = dong.DonGia
                    };

                    db.GetTable<CHITIETPHIEUNHAP>()
                      .InsertOnSubmit(ctNhap);

                    // Tăng tồn kho
                    nguyenLieu.TonKho += dong.SoLuong;

                    // Ghi lịch sử tăng kho từ phiếu nhập
                    var bienDong = new BIENDONGKHO
                    {
                        MaNL = dong.MaNL,
                        MaND = maND,
                        MaPN = phieu.MaPN,
                        NgayGhi = ngayNhap,
                        Loai = "NHAP",
                        SoLuong = dong.SoLuong
                    };

                    db.GetTable<BIENDONGKHO>()
                      .InsertOnSubmit(bienDong);
                }

                // Lưu chi tiết, tồn kho và lịch sử
                db.SubmitChanges();

                // Chỉ xác nhận khi tất cả thao tác thành công
                scope.Complete();

                return phieu.MaPN;
            }
        }
    }
}
