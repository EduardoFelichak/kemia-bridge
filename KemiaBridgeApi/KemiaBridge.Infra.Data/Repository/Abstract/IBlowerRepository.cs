using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IBlowerRepository
    {
        Task AddAsync(Blower blower);
        Task<IEnumerable<Blower>> GetAllAsync();
        Task<Blower?> GetByIdAsync(int id);
        Task UpdateAsync(Blower blower);
        Task DeleteAsync(int id);
    }
}
