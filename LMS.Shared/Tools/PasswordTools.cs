using System.Security.Cryptography;
using System.Text;

namespace LMS.Shared.Tools {
    public static class PasswordTools {

        public static string GenerateMD5(string password) {

            using (var md5 = MD5.Create()) {
                var inputBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }

        }

    }
}
