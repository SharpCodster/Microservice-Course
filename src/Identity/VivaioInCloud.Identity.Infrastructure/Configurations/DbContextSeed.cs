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

            await CreateRoles(roleManager, SolutionConstants.Authorization.Roles.ADMIN);
            await CreateRoles(roleManager, SolutionConstants.Authorization.Roles.USER);

            var adminUser = GetBaseUser(
                "3948107b-b570-4d64-8555-d16ad6119a28",
                "admin@microsoft.com", 
                "Admin", 
                "");
            await CreatUser(userManager, adminUser, SolutionConstants.Authorization.Roles.ADMIN, SolutionConstants.Authorization.Roles.USER);

            var standardUser1 = GetBaseUser(
                "13017f42-1786-4d94-9702-6e687f578a47",
                "user1@microsoft.com", 
                "John", 
                "Doe");
            await CreatUser(userManager, standardUser1, SolutionConstants.Authorization.Roles.USER);

            var standardUser2 = GetBaseUser(
                "7a63bbf1-4346-4aa7-a273-358f66224527",
                "user2@microsoft.com", 
                "Paul", 
                "Leen");
            await CreatUser(userManager, standardUser2, SolutionConstants.Authorization.Roles.USER);

        }

        private static async Task CreateRoles(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var role = new ApplicationRole(roleName)
                {
                    CreatedAtUtc = SolutionConstants.Seeding.DATE,
                    UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                    CreatedBy = SolutionConstants.Seeding.USER,
                    UpdatedBy = SolutionConstants.Seeding.USER,
                    IsDeleted = false

                };
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task CreatUser(UserManager<ApplicationUser> userManager, ApplicationUser adminUser, params string[] roles)
        {
            var userExists = await userManager.FindByIdAsync(adminUser.Id);
            if (userExists == null)
            {
                var result = await userManager.CreateAsync(adminUser, SolutionConstants.Authorization.DEFAULT_PASSWORD);

                if (result.Succeeded)
                {
                    userExists = await userManager.FindByIdAsync(adminUser.Id);
                }
            }

            foreach(var role in roles)
            {
                await userManager.AddToRoleAsync(userExists, role);
            }
        }

        public static ApplicationUser GetBaseUser(string id, string email, string name, string surname)
        {
            var newUSer = new ApplicationUser
            {
                Id = id,
                UserName = email,
                Email = email,
                Name = name,
                Surname = surname,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsDeleted = false,
                CreatedAtUtc = SolutionConstants.Seeding.DATE,
                UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                CreatedBy = SolutionConstants.Seeding.USER,
                UpdatedBy = SolutionConstants.Seeding.USER
            };

            return newUSer;
        }
    }
}

