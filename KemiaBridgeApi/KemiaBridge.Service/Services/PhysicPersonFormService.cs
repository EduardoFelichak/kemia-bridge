using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class PhysicPersonFormService : IPhysicPersonFormService
    {
        private readonly IPhysicPersonRepository _physicPersonRepository;
        private readonly IAddressRepository      _addressRepository;
        private readonly IMapper                 _personMapper;
        private readonly IMapper                 _addressMapper;

        public PhysicPersonFormService(IPhysicPersonRepository physicPersonRepository, 
                                       IAddressRepository addressRepository)
        {
            _physicPersonRepository = physicPersonRepository;
            _addressRepository      = addressRepository;
            _personMapper           = MapperConfig.GetMapper<PersonProfile>();
            _addressMapper          = MapperConfig.GetMapper<AddressProfile>();
        }

        public async Task AddAsync(PhysicPersonFormDto physicPersonFormDto)
        {
            var physicPerson = _personMapper.Map<PhysicPerson>(physicPersonFormDto.PhysicPersonDto);
            var address      = _addressMapper.Map<Address>(physicPersonFormDto.AddressDto);

            await _physicPersonRepository.AddAsync( physicPerson );
            physicPersonFormDto.PhysicPersonDto.SetNewId(physicPerson.PersonId);

            address.setPersonId(physicPerson.PersonId);
            await _addressRepository.AddAsync( address );
            physicPersonFormDto.AddressDto.setNewId(address.AddressId);
        }
    }
}
