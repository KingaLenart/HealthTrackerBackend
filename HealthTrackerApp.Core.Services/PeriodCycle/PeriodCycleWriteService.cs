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

        public async Task PeriodCycleCreate(PeriodCycleInDto periodCycleInDto)
        {
            if (periodCycleInDto.PeriodStartDate == null)
            {
                throw new Exception("You have to enter the start date of the period!");
            }
            var existingUser = await userEntity.AsQueryable().FirstOrDefaultAsync(user => user.Id == periodCycleInDto.UserId);
            if (existingUser == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var periodId = Guid.NewGuid();

            var userPeriod = new PeriodCycleEntity
            {
                Id = periodId,
                PeriodStartDate = (DateTime)periodCycleInDto.PeriodStartDate,
                IsFirstPeriod = periodCycleInDto.IsFirstPeriod,
                UserId = existingUser.Id
            };

            periodCycleEntity.Add(userPeriod);
            await healthTrackerDatabaseContext.SaveChangesAsync();
             
        }

        public async Task <PeriodCycleOutDto> PeriodCycleUpdate (PeriodCycleInDto periodCycleInDto)
        {
            var existingPeriod = await periodCycleEntity.AsQueryable().AsTracking().FirstOrDefaultAsync(period => period.Id == periodCycleInDto.Id);
            
            if (existingPeriod.PeriodStartDate == null && periodCycleInDto.PeriodStartDate == null)
            {
                throw new Exception("Enter the start date of the period!");
            }

            existingPeriod.PeriodStartDate = periodCycleInDto.PeriodStartDate ?? existingPeriod.PeriodStartDate;
            existingPeriod.IsFirstPeriod = periodCycleInDto.IsFirstPeriod ?? existingPeriod.IsFirstPeriod;
            existingPeriod.PeriodFinishiDate = periodCycleInDto?.PeriodFinishiDate;

            existingPeriod.PeriodCycleLenght = (existingPeriod.PeriodFinishiDate - existingPeriod.PeriodStartDate)?.Ticks;

            await healthTrackerDatabaseContext.SaveChangesAsync();
            
            var periodOutDto = mapper.Map<PeriodCycleOutDto>(existingPeriod);

            return periodOutDto;
        }
    }
}

