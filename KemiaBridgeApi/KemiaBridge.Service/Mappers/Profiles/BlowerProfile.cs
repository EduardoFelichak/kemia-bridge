using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class BlowerProfile : Profile
    {
        public BlowerProfile() 
        {
            CreateMap<Blower, BlowerDto>()
                .ForMember(dest => dest.BlowerId, opt => opt.Ignore());
            CreateMap<BlowerDto, Blower>()
                .ForMember(dest => dest.BlowerId, opt => opt.Ignore());
        }
    }
}
