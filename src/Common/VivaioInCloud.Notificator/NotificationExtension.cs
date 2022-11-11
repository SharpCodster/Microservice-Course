using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VivaioInCloud.Common;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Options;
using VivaioInCloud.Notificator.Service;

namespace VivaioInCloud.Notificator
{
    public static class NotificationExtension
    {
        public static IServiceCollection AddNotification(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<NotificationOptions>().Bind(configuration.GetSection(SolutionConstants.ConfigSections.NOTIFICATION)).ValidateDataAnnotations();

            return services
                .AddTransient<INotify, Notify>()
                ;
        }
    }
}
