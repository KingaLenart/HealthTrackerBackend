using HealthTrackerApp.Core.Models.PeriodsCycle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthTrackerApp.Core.SQL.Configurations.PeriodCycles
{
    internal class PeriodCycleConfiguration : IEntityTypeConfiguration<PeriodCycleEntity>
    {
        public void Configure(EntityTypeBuilder<PeriodCycleEntity> builder)
        {
            builder.ToTable("PeriodsCycle");
            builder.HasKey(periodCycle => periodCycle.Id);
            builder.HasIndex(periodCycle => periodCycle.IsFirstPeriod).IsUnique();

            builder.HasOne(periodCycle => periodCycle.User)
                .WithMany(user => user.PeriodsCycle)
                .HasForeignKey(periodCycle => periodCycle.UserId);
        }
    }
}
