using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository
{
    public interface IPhysicPersonRepository
    {
        Task AddAsync(PhysicPerson physicPerson);
        Task<IEnumerable<PhysicPerson>> GetAllAsync();
        Task<PhysicPerson?> GetByIdAsync(int id);
        Task UpdateAsync(PhysicPerson physicPerson);
        Task DeleteAsync(int id);
    }
}
