using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class PhysicPersonService : IPhysicPersonService
    {
        private readonly IPhysicPersonRepository _physicPersonRepository;
        private readonly IMapper _mapper;

        public PhysicPersonService(IPhysicPersonRepository physicPersonRepository, IMapper mapper)
        {
            _physicPersonRepository = physicPersonRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PhysicPersonDto physicPersonDto)
        {
            var physicPerson = _mapper.Map<PhysicPerson>(physicPersonDto);
            await _physicPersonRepository.AddAsync( physicPerson );
            physicPersonDto.SetNewId(physicPerson.PersonId);
        }

        public async Task<IEnumerable<PhysicPerson>> GetAllAsync()
        {
            return await _physicPersonRepository.GetAllAsync();
        }

        public async Task<PhysicPerson?> GetByIdAsync(int id)
        {
            return await _physicPersonRepository.GetByIdAsync( id );
        }

        public async Task UpdateAsync(int id, PhysicPersonDto physicPersonDto)
        {
            var physicPerson = await _physicPersonRepository.GetByIdAsync( id );
            if (physicPerson == null)
                throw new KeyNotFoundException($"Physic person with Id {id} not found");

            _mapper.Map(physicPersonDto, physicPerson);
            await _physicPersonRepository.UpdateAsync( physicPerson );
        }

        public async Task DeleteAsync(int id)
        {
            await _physicPersonRepository.DeleteAsync( id );
        }
    }
}
