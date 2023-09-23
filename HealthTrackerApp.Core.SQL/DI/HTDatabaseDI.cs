
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HealthTrackerApp.Core.SQL.DI
{
    public static class HTDatabaseDI
    {
        public static void AddHealthTrackerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HealthTrackerDatabaseContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptionsBuilder =>
                    {
                        sqlOptionsBuilder.MigrationsAssembly("HealthTrackerApp.Core.SQL");
                        sqlOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        sqlOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    });
                });
           
        }
    }
}
