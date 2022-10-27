using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VivaioInCloud.Common;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Infrastructure.Configurations
{
    public static class DbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            if (!await roleManager.RoleExistsAsync(SolutionConstants.Authorization.Roles.ADMIN))
            {
                var role = new ApplicationRole(SolutionConstants.Authorization.Roles.ADMIN)
                {
                    CreatedAtUtc = DateTime.UtcNow,
                    CreatedBy = "SEEDER",
                    UpdatedBy = "SEEDER",
                    UpdatedAtUtc = DateTime.UtcNow,
                    IsDeleted = false

                };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync(SolutionConstants.Authorization.Roles.USER))
            {
                var role = new ApplicationRole(SolutionConstants.Authorization.Roles.USER)
                {
                    CreatedAtUtc = DateTime.UtcNow,
                    CreatedBy = "SEEDER",
                    UpdatedBy = "SEEDER",
                    UpdatedAtUtc = DateTime.UtcNow,
                    IsDeleted = false

                };
                await roleManager.CreateAsync(role);
            }


            var adminUser = new ApplicationUser
            {
                UserName = "admin@microsoft.com",
                Email = "admin@microsoft.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow,
                CreatedBy = "SEEDER",
                UpdatedBy = "SEEDER"
            };

            var userExists = await userManager.FindByEmailAsync(adminUser.UserName);
            if (userExists == null)
            {
                var result = await userManager.CreateAsync(adminUser, SolutionConstants.Authorization.DEFAULT_PASSWORD);

                if (result.Succeeded)
                {
                    userExists = await userManager.FindByEmailAsync(adminUser.UserName);
                    await userManager.AddToRoleAsync(userExists, SolutionConstants.Authorization.Roles.ADMIN);
                    await userManager.AddToRoleAsync(userExists, SolutionConstants.Authorization.Roles.USER);
                }
            }

            var standardUser = new ApplicationUser
            {
                UserName = "user@microsoft.com",
                Email = "user@microsoft.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow,
                CreatedBy = "SEEDER",
                UpdatedBy = "SEEDER"
            };

            var standardUserExists = await userManager.FindByNameAsync(standardUser.UserName);
            if (standardUserExists == null)
            {
                var result = await userManager.CreateAsync(standardUser, SolutionConstants.Authorization.DEFAULT_PASSWORD);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(standardUser, SolutionConstants.Authorization.Roles.USER);
                }
            }


        }
    }
}

