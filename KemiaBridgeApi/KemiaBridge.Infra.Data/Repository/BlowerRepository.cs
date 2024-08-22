using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class BlowerRepository : IBlowerRepository
    {
        private readonly ConnectionContext _context;

        public BlowerRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Blower blower)
        {
            _context.Blowers.Add(blower);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Blower>> GetAllAsync()
        {
            return await _context.Blowers.ToListAsync();
        }

        public async Task<Blower?> GetByIdAsync(int id)
        {
            return await _context.Blowers.FindAsync(id);
        }

        public async Task UpdateAsync(Blower blower)
        {
            _context.Blowers.Update(blower);    
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blower = await _context.Blowers.FindAsync(id);
            if (blower != null)
            {
                _context.Blowers.Remove(blower);
                await _context.SaveChangesAsync();
            }
        }
    }
}
