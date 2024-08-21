using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
