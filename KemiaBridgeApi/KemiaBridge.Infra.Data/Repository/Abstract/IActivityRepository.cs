using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IActivityRepository
    {
        Task AddAsync(Activity activity);
        Task<Activity?> GetByIdAsync(int id);
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<IEnumerable<Activity>> GetByStatus(int status);
        Task UpdateAsync(Activity activity);
        Task DeleteAsync(int id);
    }
}
