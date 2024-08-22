using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class BlowerService : IBlowerService
    {
        private readonly IBlowerRepository _blowerRepository;
        private readonly IMapper           _mapper;

        public BlowerService(IBlowerRepository blowerRepository, IMapper mapper)
        {
            _blowerRepository = blowerRepository;
            _mapper           = MapperConfig.GetMapper<BlowerProfile>();
        }

        public async Task AddAsync(BlowerDto blowerDto)
        {
            var blower = _mapper.Map<Blower>(blowerDto);
            await _blowerRepository.AddAsync(blower);
            blowerDto.SetNewId(blower.BlowerId);
        }

        public async Task<IEnumerable<Blower>> GetAllAsync()
        {
            return await _blowerRepository.GetAllAsync();
        }

        public async Task<Blower?> GetByIdAsync(int id)
        {
            return await _blowerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, BlowerDto blowerDto)
        {
            var blower = await _blowerRepository.GetByIdAsync(id);
            if (blower == null)
                throw new KeyNotFoundException($"Blower with Id {id} not found");
            _mapper.Map(blowerDto, blower);
            await _blowerRepository.UpdateAsync(blower);
        }
        public async Task DeleteAsync(int id)
        {
            await _blowerRepository.DeleteAsync(id);
        }
    }
}
