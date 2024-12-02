using KemiaBridge.Domain.Entities;
using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface ITankRepository
    {
        Task AddAsync(Tank tank);
        Task<IEnumerable<Tank>> GetAllAsync();
        Task<Tank?> GetByIdAsync(int id);
        Task<IEnumerable<Tank>> GetByTypeAsync(TankType tankType);
        Task<IEnumerable<Tank>> GetByStepAsync(int id);
        Task UpdateAsync(Tank tank);
        Task DeleteAsync(int id);
    }
}
