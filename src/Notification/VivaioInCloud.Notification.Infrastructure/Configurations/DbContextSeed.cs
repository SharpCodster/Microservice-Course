using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaioInCloud.Notification.Infrastructure.Configurations
{
    public static class DbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }
    }
}
