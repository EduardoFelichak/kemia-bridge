using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;

namespace KemiaBridge.Service.Services
{
    public class SensorReadingService : ISensorReadingService
    {
        private readonly ISensorReadingRepository _sensorReadingRepository;
        private readonly IMapper _mapper;
        
        public SensorReadingService(ISensorReadingRepository sensorReadingRepository, IMapper mapper)
        {
            _sensorReadingRepository = sensorReadingRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SensorReadingDto sensorReadingDto)
        {
            var sensorReading = _mapper.Map<SensorReading>(sensorReadingDto);
            await _sensorReadingRepository.AddAsync(sensorReading);
            sensorReadingDto.setNewId(sensorReading.SensorReadingId);
        }

        public async Task DeleteAsync(int id)
        {
            await _sensorReadingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SensorReading>> GetAllAsync()
        {
            return await _sensorReadingRepository.GetAllAsync();
        }

        public async Task<SensorReading?> GetByIdAsync(int id)
        {
            return await _sensorReadingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, SensorReadingDto sensorReadingDto)
        {
            var sensorReading = await _sensorReadingRepository.GetByIdAsync(id);
            if (sensorReading == null)
                throw new KeyNotFoundException($"Sensor reading with Id {id} not found");
            _mapper.Map(sensorReadingDto, sensorReading);
            await _sensorReadingRepository.UpdateAsync(sensorReading);
        }
    }
}
