using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IStationRepository
    {
        Task AddAsync(Station station);
        Task<IEnumerable<Station>> GetAllAsync();
        Task<Station?> GetByIdAsync(int id); 
        Task UpdateAsync(Station station);
        Task DeleteAsync(int id);
    }
}
