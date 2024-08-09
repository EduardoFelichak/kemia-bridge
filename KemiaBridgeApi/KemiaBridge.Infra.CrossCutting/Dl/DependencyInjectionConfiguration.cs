using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IPhysicPersonFormService, PhysicPersonFormService>();

            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();   
            services.AddScoped<ILegalPersonService, LegalPersonService>();
        }
    }
}
