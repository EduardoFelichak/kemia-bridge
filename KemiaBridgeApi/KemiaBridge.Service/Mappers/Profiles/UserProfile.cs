using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
