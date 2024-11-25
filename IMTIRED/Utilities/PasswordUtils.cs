using System.Text;
using System.Security.Cryptography;

namespace IMTIRED.Utilities
{
    public static class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                var sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        // Add password validation logic here if needed
        public static bool ValidPassword(string password)
        {
            // Validation logic
            return true;
        }
    }
}
