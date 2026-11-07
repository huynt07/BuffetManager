using System;
using System.Collections.Generic;

namespace BuffetManager.Models
{
    public class BanPhucVuDTO
    {
        public int MaBan { get; set; }
        public int MaKV { get; set; }
        public string TenBan { get; set; }
        public string TenKV { get; set; }
        public int SoCho { get; set; }
        public int? MaLuot { get; set; }
        public string HinhThuc { get; set; }
        public string TrangThai { get; set; }

        public string HienThi
        {
            get
            {
                return TenBan + " — " + TrangThai;
            }
        }
    }
}
