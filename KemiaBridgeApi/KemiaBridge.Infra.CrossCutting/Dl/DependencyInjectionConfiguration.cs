using Microsoft.Extensions.DependencyInjection;
using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using KemiaBridge.Infra.Data.Repository.Abstract;

namespace KemiaBridge.Infra.CrossCutting.Dl
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddScopedConfig(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IPhysicPersonRepository, PhysicPersonRepository>();
            services.AddScoped<IPhysicPersonService, PhysicPersonService>();

            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();   
            services.AddScoped<ILegalPersonService, LegalPersonService>();
        }
    }
}
