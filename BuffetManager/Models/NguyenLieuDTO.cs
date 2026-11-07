using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    // Dữ liệu hiển thị trên màn hình quản lý nguyên liệu
    public class NguyenLieuDTO
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public string DonVi { get; set; }
        public string BoPhan { get; set; }
        public decimal TonKho { get; set; }
        public decimal MucCanhBao { get; set; }

        // Chuyển mã bộ phận thành tên hiển thị
        public string TenBoPhan
        {
            get
            {
                return BoPhan == "BEP" ? "Bếp" : "Pha chế";
            }
        }

        // Cảnh báo khi tồn kho bằng hoặc dưới mức quy định
        public bool CanhBao
        {
            get
            {
                return TonKho <= MucCanhBao;
            }
        }
    }
}
