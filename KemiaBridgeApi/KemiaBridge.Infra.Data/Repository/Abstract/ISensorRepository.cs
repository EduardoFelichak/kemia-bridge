using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface ISensorRepository
    {
        Task AddAsync(Sensor sensor);
        Task<Sensor?> GetByIdAsync(int id);
        Task<IEnumerable<Sensor>> GetAllAsync();
        Task UpdateAsync(Sensor sensor);
        Task DeleteAsync(int id);
    }
}
