using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface ISensorService
    {
        Task AddAsync(SensorDto sensorDto);
        Task<IEnumerable<Sensor>> GetAllAsync();
        Task<IEnumerable<Sensor>> GetByStepAsync(int id);
        Task<Sensor?> GetByIdAsync(int id);
        Task UpdateAsync(int id, SensorDto sensorDto);
        Task DeleteAsync(int id);
    }
}   
