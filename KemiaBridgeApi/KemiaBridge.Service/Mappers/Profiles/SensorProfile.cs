using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class SensorProfile : Profile
    {
        
        public SensorProfile() 
        {
            CreateMap<SensorDto, Sensor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<Sensor, SensorDto>();
        }
    }
}
