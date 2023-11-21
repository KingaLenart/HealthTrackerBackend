using HealthTrackerApp.Core.Models.Pregnancies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthTrackerApp.Core.SQL.Configurations.Pregnancies
{
    internal class PregnancyConfigurations : IEntityTypeConfiguration<PregnancyEntity>
    {
        public void Configure(EntityTypeBuilder<PregnancyEntity> builder)
        {
            builder.ToTable("Pregnancies");
            builder.HasKey(pregnancy => pregnancy.Id);

            builder.HasOne(pregnancy => pregnancy.User)
                .WithMany(user => user.Pregnancy)
                .HasForeignKey(pregnancy => pregnancy.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
