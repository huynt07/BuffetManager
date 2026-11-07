using BuffetManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Helpers
{
    public static class DbFactory
    {
        // Tạo DataContext để làm việc với database
        public static BuffetDataContext Create()
        {
            // Đọc chuỗi kết nối từ App.config
            var setting = ConfigurationManager.ConnectionStrings[
                "BuffetManager.Properties.Settings.BuffetDBConnectionString"];

            // Kiểm tra cấu hình kết nối có tồn tại và không rỗng
            if (setting == null ||
                string.IsNullOrWhiteSpace(setting.ConnectionString))
            {
                throw new InvalidOperationException(
                    "Không tìm thấy cấu hình kết nối database.");
            }

            // Tạo DataContext bằng chuỗi kết nối vừa đọc
            return new BuffetDataContext(setting.ConnectionString);
        }
    }
}
