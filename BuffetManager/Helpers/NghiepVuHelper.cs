using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using BuffetManager.Models;

namespace BuffetManager.Helpers
{
    public static class NghiepVuHelper
    {
        public static void Quyen(params string[] codes)
        {
            if (!codes.Any(UserSession.CoQuyen))
                throw new UnauthorizedAccessException("Bạn không có quyền thực hiện chức năng này.");
        }

        public static TransactionScope Transaction()
        {
            return new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable, Timeout = TimeSpan.FromSeconds(60) });
        }

        // Khóa dòng trong transaction: hai máy không cùng mở/thanh toán một bàn.
        public static void KhoaBan(BuffetDataContext db, int id)
        {
            db.ExecuteQuery<int>("SELECT MaBan FROM dbo.BAN WITH (UPDLOCK,HOLDLOCK) WHERE MaBan={0}", id).ToList();
        }

        public static void KhoaLuot(BuffetDataContext db, int id)
        {
            db.ExecuteQuery<int>("SELECT MaLuot FROM dbo.LUOTPHUCVU WITH (UPDLOCK,HOLDLOCK) WHERE MaLuot={0}", id).ToList();
        }

        public static LUOTPHUCVU DangPhucVu(BuffetDataContext db, int id)
        {
            var l = db.LUOTPHUCVUs.SingleOrDefault(x => x.MaLuot == id);
            if (l == null || l.TrangThai != "DANG_PHUC_VU")
                throw new InvalidOperationException("Lượt đã đóng hoặc đã gộp. Hãy tải lại sơ đồ bàn.");
            return l;
        }

        public static int Goc(BuffetDataContext db, int id)
        {
            var seen = new HashSet<int>();
            while (seen.Add(id))
            {
                var l = db.LUOTPHUCVUs.Single(x => x.MaLuot == id);
                if (!l.GopVaoMaLuot.HasValue)
                    return id;
                id = l.GopVaoMaLuot.Value;
            }

            throw new InvalidOperationException("Dữ liệu gộp bàn bị vòng lặp.");
        }

        // Giữ nguyên khóa ngoại của phiếu/vé; lần theo cây gộp khi tính tiền.
        public static List<int> CacLuot(BuffetDataContext db, int root)
        {
            var ids = new HashSet<int>
            {
                root
            };
            var frontier = new List<int>
            {
                root
            };
            while (frontier.Count > 0)
            {
                var next = db.LUOTPHUCVUs.Where(x => x.GopVaoMaLuot.HasValue && frontier.Contains(x.GopVaoMaLuot.Value)).Select(x => x.MaLuot).ToList();
                frontier = next.Where(x => ids.Add(x)).ToList();
            }

            return ids.ToList();
        }

        public static string TenBan(BuffetDataContext db, int root)
        {
            return string.Join(", ", (
                from lb in db.LUOTBANs
                join b in db.BANs on lb.MaBan equals b.MaBan
                where lb.MaLuot == root && lb.DenLuc == null
                orderby b.TenBan
                select b.TenBan).ToList());
        }
    }
}
