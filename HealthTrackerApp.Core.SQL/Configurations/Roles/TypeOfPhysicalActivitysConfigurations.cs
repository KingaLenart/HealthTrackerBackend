using HealthTrackerApp.Core.Models.PhysicalActivities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthTrackerApp.Core.SQL.Configurations.Roles
{
    internal class TypeOfPhysicalActivitysConfigurations : IEntityTypeConfiguration<TypeOfPhysicalActivityEntity>
    {
        public void Configure(EntityTypeBuilder<TypeOfPhysicalActivityEntity> builder)
        {
            builder.ToTable("TypeOfPhysicalActivitys");
            builder.HasKey(role => role.Id);
        }
    }
}
