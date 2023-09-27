using HealthTrackerApp.Core.Models.Authentication;
using HealthTrackerApp.Core.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HealthTrackerApp.Core.Services.Authentication
{
    public class JwtGeneratorService
    {
        private readonly AuthenticationSettings authenticationSettings;

        public JwtGeneratorService(AuthenticationSettings authenticationSettings)
        {
            this.authenticationSettings = authenticationSettings;
        }

        public string JwtGeneratorAccessToken(UserEntity existingUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.ASCII.GetBytes(authenticationSettings.JwtKey); 
            var key = new SymmetricSecurityKey(keyBytes);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, existingUser.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(authenticationSettings.JwtExpireTime),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            
            var accessToken = tokenHandler.CreateToken(tokenDescription);
            

            return tokenHandler.WriteToken(accessToken);
        }
        public string JwtGenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
