using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class TankProfile : Profile
    {
        public TankProfile() 
        { 
            CreateMap<Tank, TankDto>();
            CreateMap<TankDto, Tank>();
        }
    }
}
