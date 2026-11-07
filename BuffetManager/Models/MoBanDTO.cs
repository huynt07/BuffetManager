using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    public class MoBanDTO
    {
        // Bàn được chọn để mở
        public int MaBan { get; set; }

        // BUFFET, COMBO hoặc GOIMON
        public string HinhThuc { get; set; }

        // Có giá trị khi đón khách đã đặt trước
        // null nếu khách đến trực tiếp
        public int? MaDatBan { get; set; }

        // Chỉ có giá trị khi chọn buffet
        public int? MaGoi { get; set; }

        // Số khách buffet theo từng nhóm chiều cao
        public int SoKhachDuoi1m { get; set; }

        public int SoKhachTu1mDenDuoi1m3 { get; set; }

        public int SoKhachTu1m3 { get; set; }

        // Chỉ dùng cho hình thức buffet
        public int TongKhachBuffet
        {
            get
            {
                return SoKhachDuoi1m
                    + SoKhachTu1mDenDuoi1m3
                    + SoKhachTu1m3;
            }
        }
    }
}
