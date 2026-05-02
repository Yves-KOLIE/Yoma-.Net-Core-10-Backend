

namespace YOMA.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsValidPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static bool IsValidCode(string code, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(code, hash);
        }
    }
}