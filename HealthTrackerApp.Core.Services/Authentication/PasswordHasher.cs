using System.Security.Cryptography;
using System.Text;

namespace HealthTrackerApp.Core.Services.Authentication
{
    public class PasswordHasher
    {
        public string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public bool IsPasswordIsCorrect(string password, string hashedPassword)
        {
            string enteredPassword = Hash(password);

            return string.Equals(enteredPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
