using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface ISensorReadingService
    {
        Task AddAsync(SensorReadingDto sensorReadingDto);
        Task<IEnumerable<SensorReading>> GetAllAsync();
        Task<SensorReading?> GetByIdAsync(int id);
        Task UpdateAsync(int id, SensorReadingDto sensorReadingDto);
        Task DeleteAsync(int id);
    }
}
