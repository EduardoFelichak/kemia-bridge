using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile() 
        { 
            CreateMap<ActivityDto, Activity>()
                .ForMember(dest => dest.ActivityId, opt => opt.Ignore())
                .ForMember(dest => dest.StationId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<Activity, ActivityDto>();
        }
    }
}
