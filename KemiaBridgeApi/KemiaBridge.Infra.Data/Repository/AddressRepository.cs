using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ConnectionContext _context;

        public AddressRepository(ConnectionContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();   
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
