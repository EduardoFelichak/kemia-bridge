using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface ISensorReadingRepository
    {
        Task AddAsync(SensorReading sensorReading);
        Task<SensorReading?> GetByIdAsync(int id);
        Task<IEnumerable<SensorReading>> GetAllAsync();
        Task UpdateAsync(SensorReading sensorReading);
        Task DeleteAsync(int id);
    }
}
