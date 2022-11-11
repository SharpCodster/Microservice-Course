using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Services.Services;

namespace VivaioInCloud.Notification.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IContactService, ContactService>()
                .AddScoped<IUserNotificationService, UserNotificationService>()
                .AddScoped<IUserPreferenceService, UserPreferenceService>()
            ;
        }
    }
}