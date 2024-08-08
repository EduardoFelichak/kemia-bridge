using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IAddressService
    {
        Task AddAsync(AddressDto addressDto);
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(int id);
        Task UpdateAsync(int id, AddressDto addressDto);
        Task DeleteAsync(int id);
    }
}
