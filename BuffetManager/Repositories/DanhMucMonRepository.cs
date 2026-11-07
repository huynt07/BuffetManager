using BuffetManager.Helpers;
using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Repositories
{
    public class DanhMucMonRepository
    {
        // Lấy danh mục, sắp xếp theo tên
        public List<DANHMUCMON> LayDanhSach()
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<DANHMUCMON>()
                         .OrderBy(dm => dm.TenDM)
                         .ToList();
            }
        }

        // Thêm danh mục món mới
        public void Them(string tenDM, string boPhan)
        {
            using (var db = DbFactory.Create())
            {
                // Không cho phép trùng tên danh mục
                bool trungTen = db.GetTable<DANHMUCMON>()
                                  .Any(dm => dm.TenDM == tenDM);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên danh mục đã tồn tại.");
                }

                // MaDM được SQL Server tự tăng
                var danhMuc = new DANHMUCMON
                {
                    TenDM = tenDM,
                    BoPhan = boPhan
                };

                // Đánh dấu thêm và lưu xuống database
                db.GetTable<DANHMUCMON>().InsertOnSubmit(danhMuc);
                db.SubmitChanges();
            }
        }

        // Cập nhật tên và bộ phận của danh mục món
        public void Sua(int maDM, string tenDM, string boPhan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm danh mục cần sửa
                var danhMuc = db.GetTable<DANHMUCMON>()
                               .SingleOrDefault(dm => dm.MaDM == maDM);

                if (danhMuc == null)
                {
                    throw new InvalidOperationException(
                        "Danh mục không tồn tại hoặc đã bị xóa.");
                }

                // Không trùng tên với danh mục khác
                bool trungTen = db.GetTable<DANHMUCMON>()
                    .Any(dm => dm.TenDM == tenDM && dm.MaDM != maDM);

                if (trungTen)
                {
                    throw new InvalidOperationException(
                        "Tên danh mục đã tồn tại.");
                }

                // Chỉ kiểm tra khi người dùng muốn đổi bộ phận
                if (danhMuc.BoPhan != boPhan)
                {
                    bool daCoMon = db.GetTable<MONAN>()
                        .Any(mon => mon.MaDM == maDM);

                    if (daCoMon)
                    {
                        throw new InvalidOperationException(
                            "Danh mục đã có món, không thể đổi bộ phận.");
                    }
                }

                // Cập nhật và lưu thay đổi
                danhMuc.TenDM = tenDM;
                danhMuc.BoPhan = boPhan;

                db.SubmitChanges();
            }
        }

        // Chỉ xóa danh mục chưa có món ăn
        public void Xoa(int maDM)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm danh mục cần xóa
                var danhMuc = db.GetTable<DANHMUCMON>()
                               .SingleOrDefault(dm => dm.MaDM == maDM);

                if (danhMuc == null)
                {
                    throw new InvalidOperationException(
                        "Danh mục không tồn tại hoặc đã bị xóa.");
                }

                // Kiểm tra mọi món thuộc danh mục, kể cả món ngừng bán
                bool daCoMon = db.GetTable<MONAN>()
                                 .Any(mon => mon.MaDM == maDM);

                if (daCoMon)
                {
                    throw new InvalidOperationException(
                        "Danh mục đã có món, không thể xóa.");
                }

                // Đánh dấu xóa và lưu thay đổi
                db.GetTable<DANHMUCMON>().DeleteOnSubmit(danhMuc);
                db.SubmitChanges();
            }
        }
    }
}
