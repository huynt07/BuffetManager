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
    public class PhanQuyenRepository
    {
        // Lấy các mã chức năng được cấp cho vai trò
        public List<string> LayMaChucNang(string maVaiTro)
        {
            using (var db = DbFactory.Create())
            {
                // Nối bảng phân quyền với bảng chức năng
                var query =
                    from pq in db.GetTable<PHANQUYEN>()
                    join cn in db.GetTable<CHUCNANG>()
                        on pq.MaChucNang equals cn.MaChucNang
                    where pq.MaVaiTro == maVaiTro
                    orderby cn.MaCode
                    select cn.MaCode;

                // Đọc dữ liệu trước khi DataContext được đóng
                return query.ToList();
            }
        }

        // Thay thế quyền hiện tại bằng danh sách quyền mới
        public void LuuQuyen(string maVaiTro, List<string> cacMaQuyen)
        {
            // Không cho thay đổi quyền Admin
            if (maVaiTro == "ADMIN")
            {
                throw new InvalidOperationException(
                    "Không được thay đổi quyền Admin.");
            }

            if (cacMaQuyen == null)
            {
                throw new ArgumentException(
                    "Danh sách quyền không hợp lệ.");
            }

            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Kiểm tra vai trò tồn tại
                if (!db.GetTable<VAITRO>()
                       .Any(vt => vt.MaVaiTro == maVaiTro))
                {
                    throw new InvalidOperationException(
                        "Vai trò không tồn tại.");
                }

                // Loại bỏ mã trùng và tìm mã chức năng trong database
                var maQuyenMoi = cacMaQuyen.Distinct().ToList();

                var chucNangMoi = db.GetTable<CHUCNANG>()
                    .Where(cn => maQuyenMoi.Contains(cn.MaCode))
                    .ToList();

                if (chucNangMoi.Count != maQuyenMoi.Count)
                {
                    throw new InvalidOperationException(
                        "Có mã chức năng không tồn tại.");
                }

                // Xóa quyền cũ của đúng vai trò đang sửa
                var quyenCu = db.GetTable<PHANQUYEN>()
                    .Where(pq => pq.MaVaiTro == maVaiTro);

                db.GetTable<PHANQUYEN>().DeleteAllOnSubmit(quyenCu);
                db.SubmitChanges();

                // Thêm các quyền mới được chọn
                foreach (var chucNang in chucNangMoi)
                {
                    db.GetTable<PHANQUYEN>().InsertOnSubmit(
                        new PHANQUYEN
                        {
                            MaVaiTro = maVaiTro,
                            MaChucNang = chucNang.MaChucNang
                        });
                }

                db.SubmitChanges();

                // Chỉ xác nhận khi xóa và thêm đều thành công
                scope.Complete();
            }
        }

    }
}
