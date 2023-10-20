using AutoMapper;
using HealthTracker.Core.Common.Dto.Users;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;


namespace HealthTrackerApp.Core.Services.User
{
    public class UserReadService
    {
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        
        private readonly IMapper mapper;
        public UserReadService (HealthTrackerDatabaseContext healthTrackerDatabaseContext, IMapper mapper)
        {
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            this.mapper = mapper;
        }

        public async Task<List<UserOutDto>> GetAllUsersAsync()
        {
            var userList = await healthTrackerDatabaseContext.Set<UserEntity>().ToListAsync();
            
            var userOutDtoList = userList.Select(user => mapper.Map<UserOutDto>(user)).ToList();
            
            return userOutDtoList;
        }
    }
}
