using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class StepProfile : Profile
    {
        public StepProfile() 
        { 
            CreateMap<Step, StepDto>();
            CreateMap<StepDto, Step>();
        }
    }
}
