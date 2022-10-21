using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VivaioInCloud.Identity.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                //.AddScoped<ICatalogItemService, CatalogItemService>()
                //.AddScoped<IItemTypeService, ItemTypeService>()
            ;
        }
    }
}