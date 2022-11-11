using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Services.Services;

namespace VivaioInCloud.Catalog.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<ICatalogItemService, CatalogItemService>()
                .AddScoped<IItemTypeService, ItemTypeService>()
                .AddScoped<IUserPreferenceService, UserPreferenceService>()
            ;
        }
    }
}
