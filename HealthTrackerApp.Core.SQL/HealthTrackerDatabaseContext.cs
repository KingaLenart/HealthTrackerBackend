using HealthTrackerApp.Core.SQL.Configurations.PeriodCycles;
using HealthTrackerApp.Core.SQL.Configurations.PhysicalActivitiesConfiguration;
using HealthTrackerApp.Core.SQL.Configurations.Pregnancies;
using HealthTrackerApp.Core.SQL.Configurations.Users;
using Microsoft.EntityFrameworkCore;

namespace HealthTrackerApp.Core.SQL
{
    public class HealthTrackerDatabaseContext : DbContext
    {
        public HealthTrackerDatabaseContext(DbContextOptions<HealthTrackerDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PeriodCycleConfiguration());
            modelBuilder.ApplyConfiguration(new PregnancyConfigurations());
            modelBuilder.ApplyConfiguration(new PhysicalActivitieConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
