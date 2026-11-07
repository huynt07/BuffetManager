using BuffetManager.Helpers;
using BuffetManager.Models;
using BuffetManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Services
{
    public class ThongKeService
    {
        private readonly ThongKeRepository repository =
            new ThongKeRepository();

        // Doanh thu đủ 12 tháng của năm được chọn.
        public List<DoanhThuThangDTO> DoanhThuTheoNam(int nam)
        {
            NghiepVuHelper.Quyen("XEM_BAOCAO");

            return repository.DoanhThuTheoNam(nam);
        }

        // Doanh thu từng hình thức trong tháng được chọn.
        public List<DoanhThuHinhThucDTO> DoanhThuTheoHinhThuc(
            int thang, int nam)
        {
            NghiepVuHelper.Quyen("XEM_BAOCAO");

            return repository.DoanhThuTheoHinhThuc(thang, nam);
        }

        // Top 5 món trong tháng được chọn.
        public List<TopMonDTO> Top5MonTrongThang(int thang, int nam)
        {
            NghiepVuHelper.Quyen("XEM_BAOCAO");

            return repository.Top5MonTrongThang(thang, nam);
        }
    }
}
