using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class PersonStationService : IPersonStationService
    {
        private readonly IPersonStationRepository _personStationRepository;
        private readonly IMapper                  _mapper;

        public PersonStationService(IPersonStationRepository personStationRepository)
        {
            _personStationRepository = personStationRepository;
            _mapper                  = MapperConfig.GetMapper<PersonStationProfile>();
        }

        public async Task AddAsync(PersonStationDto personStationDto)
        {
            var personStation = _mapper.Map<PersonStation>(personStationDto);
            await _personStationRepository.AddAsync(personStation);
        }

        public async Task<IEnumerable<PersonStation>> GetAllAsync()
        {
            return await _personStationRepository.GetAllAsync();
        }

        public async Task<PersonStation?> GetByIdAsync(int id)
        {
            return await _personStationRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(PersonStationDto personStationDto)
        {
            var personStation = _mapper.Map<PersonStation>(personStationDto);
            await _personStationRepository.DeleteAsync(personStation);  
        }
    }
}
