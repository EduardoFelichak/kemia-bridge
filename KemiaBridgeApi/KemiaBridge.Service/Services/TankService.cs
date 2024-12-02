using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Domain.Enums;
using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class TankService : ITankService
    {
        private readonly ITankRepository _tankRepository;
        private readonly IMapper         _mapper;

        public TankService(ITankRepository tankRepository, IMapper mapper)
        {
            _tankRepository = tankRepository;
            _mapper         = mapper;
        }

        public async Task AddAsync(TankDto tankDto)
        {
            var tank = _mapper.Map<Tank>(tankDto);
            await _tankRepository.AddAsync(tank);
            tankDto.SetNewId(tank.TankId);
        }

        public async Task<IEnumerable<Tank>> GetAllAsync()
        {
            return await _tankRepository.GetAllAsync();
        }

        public async Task<Tank?> GetByIdAsync(int id)
        {
            return await _tankRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Tank>> GetByStepAsync(int id)
        {
            return await _tankRepository.GetByStepAsync(id);
        }

        public async Task<IEnumerable<Tank>> GetByTypeAsync(TankType tankType)
        {
            return await _tankRepository.GetByTypeAsync(tankType);  
        }

        public async Task UpdateAsync(int id, TankDto tankDto)
        {
            var tank = await _tankRepository.GetByIdAsync(id);
            if (tank == null)
                throw new KeyNotFoundException($"Tank with Id {id} not found");
            _mapper.Map(tankDto, tank);
            await _tankRepository.UpdateAsync(tank);
        }

        public async Task DeleteAsync(int id)
        {
            await _tankRepository.DeleteAsync(id);
        }
    }
}
