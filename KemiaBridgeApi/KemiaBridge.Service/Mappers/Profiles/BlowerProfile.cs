using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class BlowerProfile : Profile
    {
        public BlowerProfile() 
        { 
            CreateMap<Blower, BlowerDto>();
            CreateMap<BlowerDto, Blower>();
        }
    }
}
