using HealthTrackerApp.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace HealthTrackerApp.Core.SQL.Configurations.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.NickName).IsRequired();
            builder.HasIndex(user => user.NickName).IsUnique();

            builder.Property(user => user.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();
            
            builder.Property(user => user.Gender).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.DateOfBirth).IsRequired();
            builder.Property(user => user.Weight).IsRequired();
            builder.Property(user => user.Heights).IsRequired();

            builder.Property(user => user.RefreshTokens)
                        .HasConversion(
                            refreshToken => JsonSerializer.Serialize(refreshToken, new JsonSerializerOptions
                            {
                                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                                WriteIndented = true
                            }),
                            refreshToken => JsonSerializer.Deserialize<List<string>>(refreshToken, new JsonSerializerOptions
                            {
                                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                                WriteIndented = true
                            }));
        }
    }
}
