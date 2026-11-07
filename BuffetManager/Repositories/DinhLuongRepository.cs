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
    public class DinhLuongRepository
    {
        // Lấy danh sách nguyên liệu trong công thức của món
        public List<DinhLuongDTO> LayDanhSach(int maMon)
        {
            using (var db = DbFactory.Create())
            {
                var query =
                    from dl in db.GetTable<DINHLUONG>()
                    join nl in db.GetTable<NGUYENLIEU>()
                        on dl.MaNL equals nl.MaNL
                    where dl.MaMon == maMon
                    orderby nl.TenNL
                    select new DinhLuongDTO
                    {
                        MaMon = dl.MaMon,
                        MaNL = dl.MaNL,
                        TenNL = nl.TenNL,
                        DonVi = nl.DonVi,
                        LuongCan = dl.LuongCan
                    };

                // Thực thi truy vấn trước khi đóng DataContext
                return query.ToList();
            }
        }

        // Thêm lượng nguyên liệu cần cho một đơn vị món
        public void Them(int maMon, int maNL, decimal luongCan)
        {
            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Xác định bộ phận xử lý của món
                var boPhanMon =
                    (from mon in db.GetTable<MONAN>()
                     join dm in db.GetTable<DANHMUCMON>()
                         on mon.MaDM equals dm.MaDM
                     where mon.MaMon == maMon
                     select dm.BoPhan)
                    .SingleOrDefault();

                if (boPhanMon == null)
                {
                    throw new InvalidOperationException(
                        "Món không tồn tại hoặc danh mục không hợp lệ.");
                }

                // Kiểm tra nguyên liệu tồn tại
                var nguyenLieu = db.GetTable<NGUYENLIEU>()
                    .SingleOrDefault(nl => nl.MaNL == maNL);

                if (nguyenLieu == null)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu không tồn tại.");
                }

                // Kiểm tra lại bộ phận, không chỉ dựa vào ComboBox
                if (nguyenLieu.BoPhan != boPhanMon)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu phải cùng bộ phận với món.");
                }

                // Mỗi nguyên liệu chỉ xuất hiện một lần trong công thức
                bool daCo = db.GetTable<DINHLUONG>()
                    .Any(dl => dl.MaMon == maMon && dl.MaNL == maNL);

                if (daCo)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu đã có trong định lượng. Hãy dùng Sửa lượng.");
                }

                // Tạo dòng định lượng
                var dinhLuong = new DINHLUONG
                {
                    MaMon = maMon,
                    MaNL = maNL,
                    LuongCan = luongCan
                };

                db.GetTable<DINHLUONG>().InsertOnSubmit(dinhLuong);
                db.SubmitChanges();

                scope.Complete();
            }
        }

        // Cập nhật lượng nguyên liệu cần cho một đơn vị món
        public void Sua(int maMon, int maNL, decimal luongCan)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm đúng dòng định lượng theo món và nguyên liệu
                var dinhLuong = db.GetTable<DINHLUONG>()
                    .SingleOrDefault(dl =>
                        dl.MaMon == maMon && dl.MaNL == maNL);

                if (dinhLuong == null)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu không còn trong định lượng của món.");
                }

                // Chỉ sửa lượng cần, không đổi món hoặc nguyên liệu
                dinhLuong.LuongCan = luongCan;

                // Lưu thay đổi, không tác động đến tồn kho
                db.SubmitChanges();
            }
        }

        // Gỡ một nguyên liệu khỏi công thức của món
        public void Xoa(int maMon, int maNL)
        {
            using (var db = DbFactory.Create())
            {
                // Tìm đúng dòng định lượng theo món và nguyên liệu
                var dinhLuong = db.GetTable<DINHLUONG>()
                    .SingleOrDefault(dl =>
                        dl.MaMon == maMon && dl.MaNL == maNL);

                if (dinhLuong == null)
                {
                    throw new InvalidOperationException(
                        "Nguyên liệu không còn trong định lượng của món.");
                }

                // Chỉ xóa công thức, không xóa nguyên liệu hoặc thay đổi tồn kho
                db.GetTable<DINHLUONG>().DeleteOnSubmit(dinhLuong);
                db.SubmitChanges();
            }
        }
    }
}
