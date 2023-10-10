using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace HealthTrackerApp.Core.Services.User
{
    public class UserWriteService
    {
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        private readonly DbSet<UserEntity> userDbSet;
        
        public UserWriteService
            (HealthTrackerDatabaseContext healthTrackerDatabaseContext)
        {
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            userDbSet = healthTrackerDatabaseContext.Set<UserEntity>();
        }

        public async Task<UserEntity> UpdateUserAsync(UserInDto userInDto)
        {
            try
            {
                var existingUser = await userDbSet.AsQueryable().AsTracking().FirstOrDefaultAsync(u => u.Id == userInDto.Id);

                if (existingUser == null)
                {
                    throw new Exception("User with the provided ID not found.");
                }
                existingUser.PhoneNumber = userInDto.PhoneNumber;
                existingUser.DateOfBirth = userInDto.DateOfBirth;
                existingUser.Weight = userInDto.Weight;
                existingUser.Heights = userInDto.Heights;

                await healthTrackerDatabaseContext.SaveChangesAsync();
                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
