using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;

namespace KemiaBridge.Service.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly IMapper _mapper;

        public SensorService(ISensorRepository sensorRepository, IMapper mapper) 
        {
            _sensorRepository = sensorRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SensorDto sensorDto)
        {
            var sensor = _mapper.Map<Sensor>(sensorDto);
            await _sensorRepository.AddAsync(sensor);
            sensorDto.setNewId(sensor.SensorId);
        }

        public async Task DeleteAsync(int id)
        {
            await _sensorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Sensor>> GetAllAsync()
        {
            return await _sensorRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Sensor>> GetByStepAsync(int id)
        {
            return await _sensorRepository.GetByStepAsync(id);
        } 

        public async Task<Sensor?> GetByIdAsync(int id)
        {
            return await _sensorRepository.GetByIdAsync(id);    
        }

        public async Task UpdateAsync(int id, SensorDto sensorDto)
        {
            var sensor = await _sensorRepository.GetByIdAsync(id);
            
            if (sensor == null)
                throw new KeyNotFoundException($"Sensor with Id {id} not found");

            _mapper.Map(sensorDto, sensor);    
            await _sensorRepository.UpdateAsync(sensor);
        }
    }
}
