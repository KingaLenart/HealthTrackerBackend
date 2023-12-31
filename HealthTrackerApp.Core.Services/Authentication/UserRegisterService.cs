﻿using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace HealthTrackerApp.Core.Services.Authentication
{
    public class UserRegisterService
    {
        private readonly DbSet<UserEntity> userDbSet;
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        private readonly PasswordHasher passwordHasher;
        private readonly JwtGeneratorService jwtGeneratorService;


        public UserRegisterService(HealthTrackerDatabaseContext healthTrackerDatabaseContext, PasswordHasher passwordHasher, JwtGeneratorService jwtGeneratorService)
        {
            this.passwordHasher = passwordHasher;
            userDbSet = healthTrackerDatabaseContext.Set<UserEntity>();
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            this.jwtGeneratorService = jwtGeneratorService;
        }

        public async Task<UserAuthenticateOutDto> UserRegister(UserRegisterInDto userRegistrationInDto)
        {
            var existingUser = await userDbSet.AsQueryable().FirstOrDefaultAsync(u => u.Email == userRegistrationInDto.Email);

            if (existingUser != null)
            {
                throw new Exception("This email is already used!");
            }
            
            var userId = Guid.NewGuid();
            
            var refreshToken = jwtGeneratorService.GenerateProtectedToken(new RefreshTokenModel {UserId = userId});
            
            var user = new UserEntity
            {
                Id = userId,
                NickName = userRegistrationInDto.NickName,
                Email = userRegistrationInDto.Email,
                PhoneNumber = userRegistrationInDto.PhoneNumber,
                Gender = userRegistrationInDto.Gender,
                Role = Role.User,
                Password = passwordHasher.Hash(userRegistrationInDto.Password),
                RefreshTokens = new List<string> { refreshToken },
            };

            userDbSet.Add(user);
            await healthTrackerDatabaseContext.SaveChangesAsync();

            var accessToken = jwtGeneratorService.JwtGeneratorAccessToken(user);
            
            return new UserAuthenticateOutDto
            {
                AccesToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
