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
    public class GoiBuffetMonRepository
    {
        // Lấy mã các món đã được thêm vào gói buffet
        public List<int> LayMaMonTheoGoi(int maGoi)
        {
            using (var db = DbFactory.Create())
            {
                return db.GetTable<GOIBUFFET_MON>()
                         .Where(ct => ct.MaGoi == maGoi)
                         .Select(ct => ct.MaMon)
                         .ToList();
            }
        }

        // Lưu lại toàn bộ danh sách món của gói
        public void LuuDanhSachMon(int maGoi, List<int> cacMaMon)
        {
            if (cacMaMon == null)
            {
                throw new ArgumentException("Danh sách món không hợp lệ.");
            }

            using (var scope = new TransactionScope())
            using (var db = DbFactory.Create())
            {
                // Kiểm tra gói tồn tại
                if (!db.GetTable<GOIBUFFET>()
                       .Any(g => g.MaGoi == maGoi))
                {
                    throw new InvalidOperationException(
                        "Gói buffet không tồn tại.");
                }

                // Không đổi thực đơn khi có khách đang dùng gói
                bool dangSuDung = db.GetTable<LUOTPHUCVU>()
                    .Any(l => l.MaGoi == maGoi
                           && l.TrangThai == "DANG_PHUC_VU");

                if (dangSuDung)
                {
                    throw new InvalidOperationException(
                        "Có khách đang sử dụng gói, chưa thể sửa danh sách món.");
                }

                // Loại mã trùng và kiểm tra các món còn tồn tại
                var maMonMoi = cacMaMon.Distinct().ToList();

                int soMonTonTai = db.GetTable<MONAN>()
                    .Count(m => maMonMoi.Contains(m.MaMon));

                if (soMonTonTai != maMonMoi.Count)
                {
                    throw new InvalidOperationException(
                        "Có món không còn tồn tại. Vui lòng mở lại Form.");
                }

                // Lấy các liên kết hiện tại
                var bangLienKet = db.GetTable<GOIBUFFET_MON>();

                var lienKetCu = bangLienKet
                    .Where(ct => ct.MaGoi == maGoi)
                    .ToList();

                // Chỉ xóa những món đã bỏ tích
                var canXoa = lienKetCu
                    .Where(ct => !maMonMoi.Contains(ct.MaMon))
                    .ToList();

                bangLienKet.DeleteAllOnSubmit(canXoa);

                // Chỉ thêm những món mới được tích
                var maMonCu = lienKetCu.Select(ct => ct.MaMon).ToList();

                foreach (int maMon in maMonMoi)
                {
                    if (!maMonCu.Contains(maMon))
                    {
                        bangLienKet.InsertOnSubmit(new GOIBUFFET_MON
                        {
                            MaGoi = maGoi,
                            MaMon = maMon
                        });
                    }
                }

                // Lưu và xác nhận transaction
                db.SubmitChanges();
                scope.Complete();
            }
        }
    }
}
