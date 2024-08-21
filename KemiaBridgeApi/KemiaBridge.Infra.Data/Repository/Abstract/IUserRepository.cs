using KemiaBridge.Domain.Entities;
using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetByTypeAsync(UserTypeEnum userType);
        Task<User?> SignInAsync(string email, string password);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
