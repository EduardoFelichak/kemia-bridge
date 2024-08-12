using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class StationProfile : Profile
    {
        public StationProfile() 
        {
            CreateMap<Station, StationDto>();
            CreateMap<StationDto, Station>();
        }
    }
}
