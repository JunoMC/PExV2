using System.Security.Cryptography;
using System.Text;

namespace PExV2
{
    internal class Crypto
    {
        private string salt = Convert.ToBase64String(Encoding.UTF8.GetBytes("|PEx|2023|"));

        public string Encode(string password)
        {
            string combinedPassword = password + salt;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword;
            }
        }

        public bool Compare(string inputPassword, string storedHash)
        {
            string combinedPassword = inputPassword + salt;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword == storedHash;
            }
        }
    }
}
