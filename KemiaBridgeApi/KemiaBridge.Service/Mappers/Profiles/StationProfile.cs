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
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address!.AddressId))
                .IgnoreNullSourceValues();

            CreateMap<Station, StationDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(s => s.Steps));
        }
    }
}
