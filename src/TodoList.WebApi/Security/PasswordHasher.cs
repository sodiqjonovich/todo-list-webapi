namespace TodoList.WebApi.Security
{
    public class PasswordHasher
    {
        private const string _key = "";
        public static (string Hash, string Salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(salt + password + _key);
            return (Hash: hash, Salt: salt);
        }

        public static bool Verify(string password, string salt, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(salt + password + _key, hash);
        }

        private static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
