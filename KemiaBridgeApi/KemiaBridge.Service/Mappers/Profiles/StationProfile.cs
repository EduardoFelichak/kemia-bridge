using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class StationProfile : Profile
    {
        public StationProfile() 
        {
            CreateMap<Station, StationDto>()
                .ForMember(dest => dest.StationId, opt => opt.Ignore());
            CreateMap<StationDto, Station>()
                .ForMember(dest => dest.StationId, opt => opt.Ignore());
        }
    }
}
