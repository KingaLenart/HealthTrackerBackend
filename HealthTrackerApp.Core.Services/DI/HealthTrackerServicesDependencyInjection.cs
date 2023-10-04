using HealthTrackerApp.Core.Models.Authentication;
using HealthTrackerApp.Core.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthTrackerApp.Core.Services.DI
{
    public static class HealthTrackerServicesDependencyInjection
    {
        public static void AddHealthTrackerServices(this IServiceCollection services, IConfiguration configuration )
        {
            var tokensSettingsSection = configuration.GetSection(AuthenticationSettings.AuthenticationKey);
            services.Configure<AuthenticationSettings>(options => tokensSettingsSection.Bind(options));

            services.AddScoped<UserRegisterService>();
            services.AddScoped<UserAuthenticationService>();
            services.AddScoped<PasswordHasher>();
            services.AddScoped<JwtGeneratorService>();
        }
    }
}
