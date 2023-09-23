using HealthTrackerApp.Core.Models.PhysicalActivities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthTrackerApp.Core.SQL.Configurations.PhysicalActivitiesConfiguration
{
    internal class PhysicalActivitieConfiguration : IEntityTypeConfiguration<PhysicalActivitieEntity>
    {
        public void Configure(EntityTypeBuilder<PhysicalActivitieEntity> builder)
        {
            builder.ToTable("PhysicalActivitie");
            builder.HasKey(activitie => activitie.Id);
            builder.Property(activitie => activitie.TypeOfPhysicalActivity).IsRequired();
            builder.Property(activitie => activitie.TrainingDay).IsRequired();
            builder.Property(activitie => activitie.TrainingLength).IsRequired();

            builder.HasOne(activitie => activitie.User)
                .WithMany(user => user.PhysicalActivities)
                .HasForeignKey(activitie => activitie.UserId);



        }
    }
}
