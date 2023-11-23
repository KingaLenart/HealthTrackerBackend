using HealthTracker.Core.Common.Dto.Pregnancies;
using HealthTrackerApp.Core.Models.Pregnancies;
using HealthTrackerApp.Core.Models.Users;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace HealthTrackerApp.Core.Services.Pregnancies
{
    public class PregnancyWriteService
    {
        private readonly HealthTrackerDatabaseContext healthTrackerDatabaseContext;
        private readonly DbSet<UserEntity> userEntitiesSet;
        private readonly DbSet<PregnancyEntity> pregnancyEntities;

        public PregnancyWriteService(HealthTrackerDatabaseContext healthTrackerDatabaseContext)
        {
            this.healthTrackerDatabaseContext = healthTrackerDatabaseContext;
            userEntitiesSet = healthTrackerDatabaseContext.Set<UserEntity>();
            pregnancyEntities = healthTrackerDatabaseContext.Set<PregnancyEntity>();
        }

        public async Task PregnancyCreate(PregnancyInDto pregnancyInDto)
        {
            if (pregnancyInDto.Conceiving == null && pregnancyInDto.DueDate == null)
            {
                throw new Exception("You have to enter the conceving or due date!");
            }

            var existingUser = await userEntitiesSet.AsQueryable().FirstOrDefaultAsync(user => user.Id == pregnancyInDto.UserId);

            if (existingUser == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }
            if (existingUser.Gender == Gender.Man)
            {
                throw new Exception("The MAN can not be pregnant!");
            }


            var pregnancyId = Guid.NewGuid();

            var userPregnancy = new PregnancyEntity
            {
                Id = pregnancyId,
                UserId = existingUser.Id,
                Conceiving = pregnancyInDto.Conceiving,
                DueDate = pregnancyInDto.DueDate,
                IsGirl = pregnancyInDto.IsGirl
            };

            existingUser.IsPregnant = true;

            pregnancyEntities.Add(userPregnancy);
            await healthTrackerDatabaseContext.SaveChangesAsync();
        }

        public async Task PregnancyUpdate(PregnancyInDto pregnancyInDto)
        {
            var existingPregnancy = await pregnancyEntities.AsQueryable().AsTracking()
                .FirstOrDefaultAsync(pregnancy => pregnancy.Id == pregnancyInDto.Id);

            if (existingPregnancy == null)
            {
                throw new Exception("Pregnancy does not exist in the database");
            }

            existingPregnancy.Conceiving = pregnancyInDto.Conceiving ?? pregnancyInDto.Conceiving;
            existingPregnancy.DueDate = pregnancyInDto.DueDate ?? pregnancyInDto.DueDate;
            existingPregnancy.IsGirl = pregnancyInDto.IsGirl ?? pregnancyInDto.IsGirl;

            await healthTrackerDatabaseContext.SaveChangesAsync();
        }

        public async Task PregnancyDelete(Guid id)
        {

            var existingPregnancy = await pregnancyEntities.AsQueryable().AsTracking()
                .FirstOrDefaultAsync(pregnancy => pregnancy.Id == id);

            if (existingPregnancy == null)
            {
                throw new Exception("Pregnancy does not exist in the database");
            }

            var existingUser = await userEntitiesSet
                .FirstOrDefaultAsync(userEntitiesSet => userEntitiesSet.Id == existingPregnancy.UserId);

            existingUser.IsPregnant = false;
            
            pregnancyEntities.Remove(existingPregnancy);
            await healthTrackerDatabaseContext.SaveChangesAsync();
        }

        public async Task TerminationOfPregnancy (TerminationOfPregnancyInDto terminationOfPregnancyInDto)
        {
            var existingPregnancy = await pregnancyEntities.AsQueryable().AsTracking()
                            .FirstOrDefaultAsync(pregnancy => pregnancy.Id == terminationOfPregnancyInDto.Id);

            if (existingPregnancy == null)
            {
                throw new Exception("Pregnancy does not exist in the database");
            }

            existingPregnancy.TerminationOfPregnancy = terminationOfPregnancyInDto.TerminationOfPregnancy;
            existingPregnancy.TerminationOfPregnancyDate = terminationOfPregnancyInDto.TerminationOfPregnancyDate;
            existingPregnancy.Abortion = terminationOfPregnancyInDto.Abortion;
            existingPregnancy.Miscarriage = terminationOfPregnancyInDto.Miscarriage;

            var existingUser = await userEntitiesSet
               .FirstOrDefaultAsync(userEntitiesSet => userEntitiesSet.Id == existingPregnancy.UserId);

            existingUser.IsPregnant = false;

            await healthTrackerDatabaseContext.SaveChangesAsync();
        }
    }
}
