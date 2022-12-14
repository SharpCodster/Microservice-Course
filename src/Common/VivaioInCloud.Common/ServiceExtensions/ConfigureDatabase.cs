using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VivaioInCloud.Common.ServiceExtensions
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, string dbName, IConfiguration configuration)
            where TDbContext : DbContext
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = config!.GetConnectionString(dbName);

            if (String.IsNullOrEmpty(connectionString))
            {
                return services;
            }

            if (connectionString.ToLower().StartsWith("host"))
            {
                services.AddDbContext<TDbContext>(options =>
                options.UseNpgsql(connectionString,
                    options => {
                        options.UseAdminDatabase("initial_db");
                        options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                    }));
            }
            else if (connectionString.ToLower().StartsWith("server"))
            {
                services.AddDbContext<TDbContext>(options => options.UseSqlServer(connectionString,
                    options => {
                        options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }));
            }

            return services;
        }
    }
}
