using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class PersonStationProfile : Profile
    {
        public PersonStationProfile() 
        {
            CreateMap<PersonStation, PersonStationDto>();
            CreateMap<PersonStationDto, PersonStation>();
        }
    }
}
