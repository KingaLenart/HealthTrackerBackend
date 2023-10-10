using AutoMapper;
using HealthTracker.Core.Common.Dto.Periods;
using HealthTracker.Core.Common.Mappers.Users;
using HealthTrackerApp.Core.Models.PeriodsCycle;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace HealthTrackerApp.Core.Services.PeriodCycle
{
    public class PeriodCycleWriteService
    {
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        private readonly DbSet<UserEntity> userEntity;
        private readonly DbSet<PeriodCycleEntity> periodCycleEntity;
        private readonly IMapper mapper;

        public PeriodCycleWriteService(HealthTrackerDatabaseContext healthTrackerDatabaseContext, IMapper mapper)
        {
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            userEntity = healthTrackerDatabaseContext.Set<UserEntity>();
            periodCycleEntity = healthTrackerDatabaseContext.Set<PeriodCycleEntity>();
            this.mapper = mapper;
        }

        public async Task<PeriodCycleOutDto> PeriodCycleCreate(PeriodCycleInDto periodCycleInDto)
        {
            var existingUser = await userEntity.AsQueryable().FirstOrDefaultAsync(user => user.Id == periodCycleInDto.UserId);
            if (existingUser == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var periodId = Guid.NewGuid();

            var userPeriod = new PeriodCycleEntity
            {
                Id = periodId,
                PeriodStartDate = periodCycleInDto.PeriodStartDate,
                PeriodFinishiDate = periodCycleInDto.PeriodFinishiDate,
                IsFirstPeriod = periodCycleInDto.IsFirstPeriod,
                UserId = existingUser.Id
            };

            userPeriod.PeriodCycleLenght = (userPeriod.PeriodFinishiDate - userPeriod.PeriodStartDate).Ticks;
            
            periodCycleEntity.Add(userPeriod);
            await healthTrackerDatabaseContext.SaveChangesAsync();
            
            var userPeriodOutDto = mapper.Map<PeriodCycleOutDto>(userPeriod);
                
             
            return userPeriodOutDto;
        }
    }
}

