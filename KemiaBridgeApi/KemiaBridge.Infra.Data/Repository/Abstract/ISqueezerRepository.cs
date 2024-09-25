using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface ISqueezerRepository
    {
        Task AddAsync(Squeezer squeezer);
        Task<IEnumerable<Squeezer>> GetAllAsync();
        Task<Squeezer?> GetByIdAsync(int id);
        Task UpdateAsync(Squeezer squeezer);
        Task DeleteAsync(int id);
    }
}
