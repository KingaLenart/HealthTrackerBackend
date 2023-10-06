using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HealthTrackerApp.Core.Services.Authentication
{
    public class UserAuthenticationService
    {
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        private readonly DbSet<UserEntity> userDbSet;
        private readonly PasswordHasher passwordHasher;
        private readonly JwtGeneratorService jwtGeneratorService;

        public UserAuthenticationService
            (HealthTrackerDatabaseContext healthTrackerDatabaseContext, 
            PasswordHasher passwordHasher, 
            JwtGeneratorService jwtGeneratorService)
        {
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            this.userDbSet = healthTrackerDatabaseContext.Set<UserEntity>();
            this.passwordHasher = passwordHasher;
            this.jwtGeneratorService = jwtGeneratorService;
        }

        public async Task<UserAuthenticateOutDto> AuthenticateUserAndGenerateTokens(UserAuthenticateInDto userInDto)
        {
            var existingUser = await userDbSet.AsQueryable().AsTracking().FirstOrDefaultAsync(user => user.Email == userInDto.Email);

            if (existingUser == null)
            {
                throw new InvalidOperationException("Nie ma takiego użytkownika");
            }

            if (!(passwordHasher.IsPasswordIsCorrect(userInDto.Password, existingUser.Password)))
            {
                throw new UnauthorizedAccessException("Nieprawidłowy adres email lub hasło!");
            }

            var userId = existingUser.Id;

            var acceessToken = jwtGeneratorService.JwtGeneratorAccessToken(existingUser);
            var refreshTokens = jwtGeneratorService.GenerateProtectedToken(new RefreshTokenModel {UserId = userId});

            if (existingUser.RefreshTokens  == null)
            {
                existingUser.RefreshTokens = new List<string>(); 
            }

            existingUser.RefreshTokens.Add(refreshTokens);

            healthTrackerDatabaseContext.Entry(existingUser).Property(user => user.RefreshTokens).IsModified = true;
            await healthTrackerDatabaseContext.SaveChangesAsync();

            var userAuthOutDto = new UserAuthenticateOutDto
            {
                AccesToken = acceessToken,
                RefreshToken = refreshTokens
            };

            return userAuthOutDto;
        }

        public async Task<UserAuthenticateOutDto> ValidateAndGenerateTokens (string refreshToken)
        {
            var refreshTokenModel = jwtGeneratorService.DeserializeAndVerifyProtectedToken(refreshToken);
            
            if(refreshTokenModel == null)
            {
                throw new Exception("The token is null");
            }

            var existingUser = await userDbSet.AsQueryable().FirstOrDefaultAsync(user => user.Id.Equals(refreshTokenModel.UserId));

            if (existingUser == null)
            {
                throw new InvalidOperationException("Nie ma takiego użytkownika");
            }

            if (!existingUser.RefreshTokens.Contains(refreshToken))
            {
                throw new Exception("User doesn't have this token");
            }

            var accessToken = jwtGeneratorService.JwtGeneratorAccessToken(existingUser);

            var response = new UserAuthenticateOutDto
            {
                AccesToken = accessToken,
                RefreshToken = refreshToken
            };

            return response;
        }
    }
}
