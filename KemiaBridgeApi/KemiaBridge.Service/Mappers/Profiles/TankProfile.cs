using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class TankProfile : Profile
    {
        public TankProfile() 
        {
            CreateMap<TankDto, Tank>()
                .ForMember(dest => dest.TankId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<Tank, TankDto>();
        }
    }
}
