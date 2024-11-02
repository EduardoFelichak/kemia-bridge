using KemiaBridge.Domain.DTos;

namespace KemiaBridge.Service.Interface
{
    public interface IActivityService
    {
        Task AddAsync(ActivityDto activityDto);
        Task<IEnumerable<ActivityDto>> GetAllAsync();
        Task<ActivityDto?> GetByIdAsync(int id);
        Task<IEnumerable<ActivityDto>> GetByStatusAsync(int status);
        Task UpdateAsync(int id, ActivityDto activityDto);
        Task DeleteAsync(int id);
    }
}
