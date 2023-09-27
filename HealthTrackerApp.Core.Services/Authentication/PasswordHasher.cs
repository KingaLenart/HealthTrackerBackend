using System.Security.Cryptography;
using System.Text;

namespace HealthTrackerApp.Core.Services.Authentication
{
    internal class PasswordHasher
    {
        public string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
