using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Mappers.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PhysicPerson, PhysicPersonDto>()
                .IncludeBase<Person, PersonDto>();
            CreateMap<LegalPerson, LegalPersonDto>()
                .IncludeBase<Person, PersonDto>();

            CreateMap<PersonDto, Person>();
            CreateMap<PhysicPersonDto, PhysicPerson>()
                .IncludeBase<PersonDto, Person>();
            CreateMap<LegalPersonDto, LegalPerson>()
                .IncludeBase<PersonDto, Person>();
        }
    }
}
