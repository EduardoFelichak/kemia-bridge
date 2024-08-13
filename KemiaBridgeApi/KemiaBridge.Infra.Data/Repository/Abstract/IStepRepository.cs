using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IStepRepository
    {
        Task AddAsync(Step step);
        Task<IEnumerable<Step>> GetAllAsync();
        Task<Step?> GetByIdAsync(int id);
        Task UpdateAsync(Step step);
        Task DeleteAsync(int id);
    }
}
