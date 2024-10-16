using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class SqueezerProfile : Profile
    {
        public SqueezerProfile() 
        {
            CreateMap<SqueezerDto, Squeezer>()
                .ForMember(dest => dest.SqueezerId, opt => opt.Ignore())
                .IgnoreNullSourceValues();
        }
    }
}
