using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Services.Services;

namespace VivaioInCloud.Identity.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IApplicationUserService, ApplicationUserService>()
                .AddScoped<IClientSecretService, ClientSecretService>()
                .AddScoped<IRolesService, RolesService>()
                .AddScoped<ITokenClaimsService, TokenClaimService>()
                .AddScoped<IUserAuthenticationManager, UserAuthenticationManager>()
                .AddScoped<IApplicationRoleService, ApplicationRoleService>()
                .AddScoped<IUserRegistrationService, UserRegistrationService>()
            ;
        }
    }
}