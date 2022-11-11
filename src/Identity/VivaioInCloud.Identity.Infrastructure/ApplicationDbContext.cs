using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Infrastructure
{
    // add-migration {name} -Context ApplicationDbContext
    // update-database -Context ApplicationDbContext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //"AspNetUsers"
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "ApplicationUsers", schema: "dbo");
            });
            //"AspNetRoles"
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "IdentityRoles", schema: "dbo");
            });
            //"AspNetUserRoles"
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("IdentityUserUserRoles", schema: "dbo");
            });
            //"AspNetUserClaims"
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("IdentityUserClaims", schema: "dbo");
            });
            //"AspNetUserLogins
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("IdentityUserLogins", schema: "dbo");
            });
            //"AspNetRoleClaims
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("IdentityRoleClaims", schema: "dbo");
            });
            //"AspNetUserTokens"
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("IdentityUserTokens", schema: "dbo");
            });


            Assembly ass = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(ass);
        }
    }
}