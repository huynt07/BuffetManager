using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Models
{
    public class DatBanDTO
    {
        public int MaDatBan { get; set; }
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public DateTime GioDen { get; set; }
        public int SoKhach { get; set; }
        public string TrangThai { get; set; }

        // Nội dung hiển thị trên bảng
        public string TenTrangThai
        {
            get
            {
                switch (TrangThai)
                {
                    case "CHO":
                        return "Chờ khách";
                    case "DA_DEN":
                        return "Đã đến";
                    case "HUY":
                        return "Đã hủy";
                    default:
                        return TrangThai;
                }
            }
        }
    }
}
