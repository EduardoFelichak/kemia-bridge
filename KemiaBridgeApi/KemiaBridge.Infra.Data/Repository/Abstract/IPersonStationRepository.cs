using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface IPersonStationRepository
    {
        Task AddAsync(PersonStation personStation);
        Task<IEnumerable<PersonStation>> GetAllAsync();
        Task<PersonStation?> GetByIdAsync(int id);
        Task UpdateAsync(PersonStation personStation);
        Task DeleteAsync(int id);
    }
}
