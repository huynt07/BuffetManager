using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuffetManager.Helpers
{
    public static class PasswordHelper
    {
        // Tạo Salt ngẫu nhiên gồm 32 byte cho mỗi mật khẩu mới
        public static byte[] CreateSalt()
        {
            byte[] salt = new byte[32];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
        }

        // Băm dữ liệu theo thứ tự: Salt + mật khẩu UTF-8
        public static byte[] HashPassword(string password, byte[] salt)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (salt == null || salt.Length != 32)
                throw new ArgumentException("Salt phải có 32 byte.");

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Tạo mảng chứa Salt và mật khẩu
            byte[] data = new byte[salt.Length + passwordBytes.Length];

            Buffer.BlockCopy(salt, 0, data, 0, salt.Length);

            Buffer.BlockCopy(
                passwordBytes, 0,
                data, salt.Length,
                passwordBytes.Length);

            // SHA-256 trả về kết quả gồm 32 byte
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        // Kiểm tra mật khẩu nhập vào với Hash và Salt đã lưu
        public static bool VerifyPassword(
            string password, byte[] salt, byte[] storedHash)
        {
            if (password == null ||
                salt == null || salt.Length != 32 ||
                storedHash == null || storedHash.Length != 32)
            {
                return false;
            }

            byte[] inputHash = HashPassword(password, salt);

            // So sánh toàn bộ 32 byte, không dừng ở byte khác đầu tiên
            int difference = 0;

            for (int i = 0; i < inputHash.Length; i++)
            {
                difference |= inputHash[i] ^ storedHash[i];
            }

            return difference == 0;
        }
    }
}
