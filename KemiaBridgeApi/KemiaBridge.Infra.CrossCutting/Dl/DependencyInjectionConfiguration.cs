using Microsoft.Extensions.DependencyInjection;
using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;

namespace KemiaBridge.Infra.CrossCutting.Dl
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddScopedConfig(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
