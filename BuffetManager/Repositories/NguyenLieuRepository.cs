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
    public class NguyenLieuRepository
    {
        // Lấy danh sách nguyên liệu cho màn hình quản lý kho
        public List<NguyenLieuDTO> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<NGUYENLIEU>()
                    .OrderBy(nl => nl.BoPhan)
                    .ThenBy(nl => nl.TenNL)
                    .Select(nl => new NguyenLieuDTO
                    {
                        MaNL = nl.MaNL,
                        TenNL = nl.TenNL,
                        DonVi = nl.DonVi,
                        BoPhan = nl.BoPhan,
                        TonKho = nl.TonKho,
                        MucCanhBao = nl.MucCanhBao
                    })
                    .ToList();
            }
        }

        // Thêm nguyên liệu mới, chưa có tồn kho
        public void Them(
            string tenNL,
            string donVi,
            string boPhan,
            decimal mucCanhBao)
        {
            using (var db = DbFactory.Create())
            {
                // Không trùng tên nguyên liệu trong cùng bộ phận
                bool trungTen = db.GetTable<NGUYENLIEU>()
                    .Any(nl => nl.TenNL == tenNL && nl.BoPhan == boPhan);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên nguyên liệu đã tồn tại trong bộ phận này.");
                }

                // Tồn kho chỉ tăng thông qua nghiệp vụ nhập kho
                var nguyenLieu = new NGUYENLIEU
                {
                    TenNL = tenNL,
                    DonVi = donVi,
                    BoPhan = boPhan,
                    TonKho = 0,
                    MucCanhBao = mucCanhBao
                };

                // MaNL và PhienBan do SQL Server tự sinh
                db.GetTable<NGUYENLIEU>().InsertOnSubmit(nguyenLieu);
                db.SubmitChanges();
            }
        }

        // Cập nhật thông tin nguyên liệu, không sửa tồn kho
        public void Sua(
            int maNL,
            string tenNL,
            string donVi,
            string boPhan,
            decimal mucCanhBao)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Tìm nguyên liệu cần sửa
                var nguyenLieu = db.GetTable<NGUYENLIEU>()
                    .SingleOrDefault(nl => nl.MaNL == maNL);

                if (nguyenLieu == null)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu không tồn tại hoặc đã bị xóa.");
                }

                // Không trùng tên với nguyên liệu khác trong cùng bộ phận
                bool trungTen = db.GetTable<NGUYENLIEU>()
                    .Any(nl => nl.TenNL == tenNL
                            && nl.BoPhan == boPhan
                            && nl.MaNL != maNL);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên nguyên liệu đã tồn tại trong bộ phận này.");
                }

                // Chỉ kiểm tra ràng buộc này khi đổi đơn vị hoặc bộ phận
                bool doiDonViHoacBoPhan =
                    nguyenLieu.DonVi != donVi ||
                    nguyenLieu.BoPhan != boPhan;

                if (doiDonViHoacBoPhan)
                {
                    bool daSuDung =
                        nguyenLieu.TonKho != 0 ||
                        db.GetTable<DINHLUONG>()
                            .Any(dl => dl.MaNL == maNL) ||
                        db.GetTable<CHITIETPHIEUNHAP>()
                            .Any(ct => ct.MaNL == maNL) ||
                        db.GetTable<BIENDONGKHO>()
                            .Any(bd => bd.MaNL == maNL);

                    if (daSuDung)
                    {
                        throw new InvalidOperationException(
                            "Nguyên liệu đã được sử dụng, "
                            + "không thể đổi đơn vị hoặc bộ phận.");
                    }
                }

                // Cập nhật thông tin, giữ nguyên TonKho và PhienBan
                nguyenLieu.TenNL = tenNL;
                nguyenLieu.DonVi = donVi;
                nguyenLieu.BoPhan = boPhan;
                nguyenLieu.MucCanhBao = mucCanhBao;

                db.SubmitChanges();
                scope.Complete();
            }
        }

        // Chỉ xóa nguyên liệu chưa được sử dụng
        public void Xoa(int maNL)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Tìm nguyên liệu cần xóa
                var nguyenLieu = db.GetTable<NGUYENLIEU>()
                    .SingleOrDefault(nl => nl.MaNL == maNL);

                if (nguyenLieu == null)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu không tồn tại hoặc đã bị xóa.");
                }

                // Không xóa nguyên liệu còn tồn kho
                if (nguyenLieu.TonKho != 0)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu còn tồn kho, không thể xóa.");
                }

                // Kiểm tra nguyên liệu đang có trong công thức món
                if (db.GetTable<DINHLUONG>()
                      .Any(dl => dl.MaNL == maNL))
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu đã có trong định lượng món, không thể xóa.");
                }

                // Kiểm tra lịch sử nhập kho
                if (db.GetTable<CHITIETPHIEUNHAP>()
                      .Any(ct => ct.MaNL == maNL))
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu đã có lịch sử nhập kho, không thể xóa.");
                }

                // Kiểm tra lịch sử biến động kho
                if (db.GetTable<BIENDONGKHO>()
                      .Any(bd => bd.MaNL == maNL))
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu đã có lịch sử biến động kho, không thể xóa.");
                }

                // Xóa và xác nhận transaction
                db.GetTable<NGUYENLIEU>().DeleteOnSubmit(nguyenLieu);
                db.SubmitChanges();

                scope.Complete();
            }
        }

        // Lấy nguyên liệu thuộc cùng bộ phận xử lý với món
        public List<NguyenLieuDTO> LayTheoMon(int maMon)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm bộ phận của món thông qua danh mục
                var boPhan =
                    (from mon in db.GetTable<MONAN>()
                     join dm in db.GetTable<DANHMUCMON>()
                         on mon.MaDM equals dm.MaDM
                     where mon.MaMon == maMon
                     select dm.BoPhan)
                    .SingleOrDefault();

                if (boPhan == null)
                {
                    throw new InvalidOperationException(
                        "Món không tồn tại hoặc không có danh mục hợp lệ.");
                }

                // Chỉ lấy nguyên liệu của bộ phận vừa tìm được
                return db.GetTable<NGUYENLIEU>()
                    .Where(nl => nl.BoPhan == boPhan)
                    .OrderBy(nl => nl.TenNL)
                    .Select(nl => new NguyenLieuDTO
                    {
                        MaNL = nl.MaNL,
                        TenNL = nl.TenNL,
                        DonVi = nl.DonVi,
                        BoPhan = nl.BoPhan,
                        TonKho = nl.TonKho,
                        MucCanhBao = nl.MucCanhBao
                    })
                    .ToList();
            }
        }
    }
}
