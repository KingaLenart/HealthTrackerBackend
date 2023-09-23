using HealthTrackerApp.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthTrackerApp.Core.SQL.Configurations.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.NickName).IsRequired();
            builder.HasIndex(user => user.NickName).IsUnique();
            builder.Property(user => user.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.DateOfBirth).IsRequired();
            builder.Property(user => user.Weight).IsRequired();
            builder.Property(user => user.Heights).IsRequired();

            builder.HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(user => user.Role)
                .IsRequired();
        }
    }
}
