using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());
            CreateMap<PhysicPerson, PhysicPersonDto>()
                .IncludeBase<Person, PersonDto>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());
            CreateMap<LegalPerson, LegalPersonDto>()
                .IncludeBase<Person, PersonDto>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());

            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());
            CreateMap<PhysicPersonDto, PhysicPerson>()
                .IncludeBase<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());
            CreateMap<LegalPersonDto, LegalPerson>()
                .IncludeBase<PersonDto, Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore());
        }
    }
}
