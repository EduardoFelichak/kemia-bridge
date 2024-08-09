using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ILegalPersonRepository _legalPersonRepository;
        private readonly IMapper _mapper;
        private readonly IAddressValidator _addressValidator;

        public LegalPersonService(ILegalPersonRepository legalPersonRepository,
                                  IAddressValidator addressValidator)
        {
            _legalPersonRepository = legalPersonRepository;
            _addressValidator = addressValidator;
            _mapper = MapperConfig.GetMapper<PersonProfile>();
        }

        public async Task AddAsync(LegalPersonDto legalPersonDto)
        {
            var legalPerson = _mapper.Map<LegalPerson>(legalPersonDto);

            if (!_addressValidator.Exists(legalPerson.AddressId))
                throw new KeyNotFoundException("Address not found");

            await _legalPersonRepository.AddAsync( legalPerson );
            legalPersonDto.setNewId(legalPerson.PersonId);
        }

        public async Task<IEnumerable<LegalPerson>> GetAllAsync()
        {
            return await _legalPersonRepository.GetAllAsync();
        }

        public async Task<LegalPerson?> GetByIdAsync(int id)
        {
            return await _legalPersonRepository.GetByIdAsync( id );
        }

        public async Task UpdateAsync(int id, LegalPersonDto legalPersonDto)
        {
            var legalPerson = await _legalPersonRepository.GetByIdAsync(id);
            if (legalPerson == null)
                throw new KeyNotFoundException($"Legal person with Id {id} not found");
            await _legalPersonRepository.AddAsync( legalPerson );
        }

        public async Task DeleteAsync(int id)
        {
            await _legalPersonRepository.DeleteAsync( id ); 
        }
    }
}
