using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IPhysicPersonService
    {
        Task AddAsync(PhysicPersonDto physicPersonDto);
        Task<IEnumerable<PhysicPerson>> GetAllAsync();
        Task<PhysicPerson?> GetByIdAsync(int id);
        Task UpdateAsync(int id, PhysicPersonDto physicPersonDto);
        Task DeleteAsync(int id);
    }
}
