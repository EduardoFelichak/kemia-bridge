using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository
{
    public interface IAddressRepository
    {
        Task AddAsync(Address address);
        Task<Address> GetByIdAsync(int id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}
