using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IBlowerService
    {
        Task AddAsync(BlowerDto blowerDto);
        Task<IEnumerable<Blower>> GetAllAsync();
        Task<Blower?> GetByIdAsync(int id);
        Task UpdateAsync(int id, BlowerDto blowerDto);
        Task DeleteAsync(int id);
    }
}
