using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.Authentication;
using HealthTrackerApp.Core.Models.Users;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthTrackerApp.Core.Services.Authentication
{
    public class JwtGeneratorService
    {
        private readonly AuthenticationSettings authenticationSettings;
        private readonly IDataProtectionProvider dataProtectionProvider;

        public JwtGeneratorService(IOptions<AuthenticationSettings> authenticationSettings, IDataProtectionProvider dataProtectionProvider)
        {
            this.authenticationSettings = authenticationSettings.Value;
            this.dataProtectionProvider = dataProtectionProvider;
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
        public string GenerateProtectedToken(RefreshTokenModel tokenModel)
        {
            var toProtect = JsonConvert.SerializeObject(tokenModel);
            var protector = dataProtectionProvider.CreateProtector(authenticationSettings.JwtKey);
            return protector.Protect(toProtect);
        }

        public RefreshTokenModel DeserializeAndVerifyProtectedToken(string encryptedToken)
        {
            var protector = dataProtectionProvider.CreateProtector(authenticationSettings.JwtKey);
            try
            {
                var decryptedToken = protector.Unprotect(encryptedToken);
                var tokenData = JsonConvert.DeserializeObject<RefreshTokenModel>(decryptedToken);
                
                return tokenData;
            }
            catch (Exception)
            {
                throw new Exception("Failed to verify token.");
            }
        }
    }
}
