using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public static class Utils
    {
        private const int PBKDF2IterCount = 100000;

        private const int PBKDF2SubkeyLength = 160 / 8;

        private const int saltSize = 128 / 8;

        public static Tuple<string, string> CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, PBKDF2IterCount))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

                return Tuple.Create(Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }

        public static bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount))
            {
                var generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                return hashedPasswordBytes.SequenceEqual(generatedSubkey);
            }
        }

        public static (string, string) GetPassAndSalt(string passwordHash)
        {
            var result = passwordHash.Split(',');
            if (result.Count() != 2)
            {
                return (string.Empty, string.Empty);
            }
            return (result[0], result[1]);
        }

        public static string HashPassword(string password)
        {
            var (hash, salt) = CreateHash(password);
            return string.Join(',', hash, salt);
        }
    }
}
