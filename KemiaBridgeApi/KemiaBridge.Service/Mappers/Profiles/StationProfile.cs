using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class StationProfile : Profile
    {
        public StationProfile() 
        {
            CreateMap<StationDto, Station>()
                .ForMember(dest => dest.StationId, opt => opt.Ignore())
                .IgnoreNullSourceValues();
        }
    }
}
