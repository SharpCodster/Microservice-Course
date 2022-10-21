using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaioInCloud.Common.ServiceExtensions
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddAutoMapperWithConfig(this IServiceCollection services)
        {
            var allTypes = GetAutoMapperProfilesFromAllAssemblies().ToArray();
            return services.AddAutoMapper(allTypes);
        }

        private static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(_ => _.FullName.StartsWith("VivaioInCloud")).ToList();

            foreach (var assembly in assemblies)
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }
    }
}

