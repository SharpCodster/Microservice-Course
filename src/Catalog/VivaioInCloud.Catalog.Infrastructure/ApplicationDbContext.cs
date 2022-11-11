using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VivaioInCloud.Catalog.Entities.Models;

namespace VivaioInCloud.Catalog.Infrastructure
{
    // add-migration {name} -Context ApplicationDbContext
    // update-database -Context ApplicationDbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Assembly ass = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(ass);
        }
    }
}
