using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface ISqueezerService
    {
        Task AddAsync(SqueezerDto squeezerDto);
        Task<IEnumerable<Squeezer>> GetAllAsync();
        Task<Squeezer?> GetByIdAsync(int id);
        Task UpdateAsync(int id, SqueezerDto squeezerDto);
        Task DeleteAsync(int id);
    }
}
