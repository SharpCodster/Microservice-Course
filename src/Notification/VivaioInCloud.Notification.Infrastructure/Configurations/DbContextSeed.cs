using Microsoft.EntityFrameworkCore;

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
