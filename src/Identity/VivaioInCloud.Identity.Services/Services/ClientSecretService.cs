using System.Security.Cryptography;
using VivaioInCloud.Identity.Abstraction.Services;

namespace VivaioInCloud.Identity.Services.Services
{
    internal class ClientSecretService : IClientSecretService
    {
        private static int SECRET_LENGTH = 40;
        private static int SALT_LENGTH = 16;
        private static int ITERATIONS = 10000;

        public string GenerateNewAppSecret()
        {
            var randomNumber = new byte[SECRET_LENGTH];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            var base64 = Convert.ToBase64String(randomNumber);
            return base64;
        }

        public string GenerateSecretHash(string secret)
        {
            byte[] salt;
            (new RNGCryptoServiceProvider()).GetBytes(salt = new byte[SALT_LENGTH]);

            var pbkdf2 = new Rfc2898DeriveBytes(secret, salt, ITERATIONS);
            byte[] hash = pbkdf2.GetBytes(SECRET_LENGTH);

            byte[] hashBytes = new byte[SECRET_LENGTH + SALT_LENGTH];
            Array.Copy(salt, 0, hashBytes, 0, SALT_LENGTH);
            Array.Copy(hash, 0, hashBytes, SALT_LENGTH, SECRET_LENGTH);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public bool CheckSecret(string savedSecret, string enteredSecret)
        {
            bool res = true;
            /* Fetch the stored value */
            string savedPasswordHash = savedSecret;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[SALT_LENGTH];
            Array.Copy(hashBytes, 0, salt, 0, SALT_LENGTH);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(enteredSecret, salt, ITERATIONS);
            byte[] hash = pbkdf2.GetBytes(SECRET_LENGTH);
            /* Compare the results */
            for (int i = 0; i < SECRET_LENGTH; i++)
            {
                if (hashBytes[i + SALT_LENGTH] != hash[i])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}
