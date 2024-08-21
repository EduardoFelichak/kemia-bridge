using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IUserService
    {
        Task AddAsync(UserDto userDto);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> SignInAsync(string email, string password);
        Task UpdateAsync(int id, UserDto userDto);
        Task DeleteAsync(int id);
    }
}
