using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KemiaBridge.Infra.CrossCutting.Dl
{
    public static class DIConfiguration
    {
        public static void AddScopedConfig(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IPhysicPersonRepository, PhysicPersonRepository>();
            services.AddScoped<IPhysicPersonService, PhysicPersonService>();

            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();   
            services.AddScoped<ILegalPersonService, LegalPersonService>();

            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IStationService, StationService>();

            services.AddScoped<IPersonStationRepository, PersonStationRepository>();
            services.AddScoped<IPersonStationService, PersonStationService>();

            services.AddScoped<IStepRepository, StepRepository>(); 
            services.AddScoped<IStepService, StepService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITankRepository, TankRepository>();
            services.AddScoped<ITankService, TankService>();

            services.AddScoped<IBlowerRepository, BlowerRepository>();
            services.AddScoped<IBlowerService, BlowerService>();

            services.AddScoped<ISqueezerRepository, SqueezerRepository>();
            services.AddScoped<ISqueezerService, SqueezerService>();
        }
    }
}
