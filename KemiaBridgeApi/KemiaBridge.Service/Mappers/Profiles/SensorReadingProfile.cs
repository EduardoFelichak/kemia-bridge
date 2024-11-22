using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class SensorReadingProfile : Profile
    {
        public SensorReadingProfile() 
        {
            CreateMap<SensorReadingDto, SensorReading>()
                .ForMember(dest => dest.SensorReadingId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<SensorReading, SensorReadingDto>();
        }
    }
}
