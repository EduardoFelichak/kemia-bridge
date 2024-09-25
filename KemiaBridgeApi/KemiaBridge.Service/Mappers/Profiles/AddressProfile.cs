using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.AddressId, opt => opt.Ignore());
        }
    }
}
