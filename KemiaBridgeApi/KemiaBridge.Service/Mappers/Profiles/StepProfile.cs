using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class StepProfile : Profile
    {
        public StepProfile() 
        {
            CreateMap<StepDto, Step>()
                .ForMember(dest => dest.StepId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<Step, StepDto>();
        }
    }
}
