using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Service.Interface
{
    public interface ITankService
    {
        Task AddAsync(TankDto tankDto);
        Task<IEnumerable<Tank>> GetAllAsync();
        Task<IEnumerable<Tank>> GetByStepAsync(int id);
        Task<Tank?> GetByIdAsync(int id);
        Task<IEnumerable<Tank>> GetByTypeAsync(TankType tankType);
        Task UpdateAsync(int id, TankDto tankDto);
        Task DeleteAsync(int id);
    }
}
