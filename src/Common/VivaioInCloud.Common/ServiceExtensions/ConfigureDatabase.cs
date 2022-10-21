using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaioInCloud.Common.ServiceExtensions
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, string dbName, IConfiguration configuration)
            where TDbContext : DbContext
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = config!.GetConnectionString(dbName);
            return services.AddDbContext<TDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
