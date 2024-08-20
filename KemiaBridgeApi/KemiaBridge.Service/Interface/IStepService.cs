using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IStepService
    {
        Task AddAsync(StepDto stepDto);
        Task<IEnumerable<Step>> GetAllAsync();
        Task<Step?> GetByIdAsync(int id);
        Task UpdateAsync(int id, StepDto stepDto);
        Task DeleteAsync(int id);
    }
}
