using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<PhysicPersonDto, PhysicPerson>()
                .IncludeBase<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore())
                .IgnoreNullSourceValues();

            CreateMap<LegalPersonDto, LegalPerson>()
                .IncludeBase<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore())
                .IgnoreNullSourceValues();
        }
    }
}
