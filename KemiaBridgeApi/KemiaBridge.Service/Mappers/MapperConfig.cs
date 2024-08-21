using AutoMapper;
using KemiaBridge.Service.Mappers.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace KemiaBridge.Service.Mappers
{
    public static class MapperConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AddressProfile));
            services.AddAutoMapper(typeof(PersonProfile));  
            services.AddAutoMapper(typeof(StationProfile));
            services.AddAutoMapper(typeof(PersonStationProfile));
            services.AddAutoMapper(typeof(StepProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(TankProfile));
        }

        public static IMapper GetMapper<TProfile>() where TProfile : Profile, new()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });

            return config.CreateMapper();
        }
    }
}
