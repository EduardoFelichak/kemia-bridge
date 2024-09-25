using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class SqueezerRepository : ISqueezerRepository
    {
        private readonly ConnectionContext _context;

        public SqueezerRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Squeezer squeezer)
        {
            _context.Squeezers.Add(squeezer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Squeezer>> GetAllAsync()
        {
            return await _context.Squeezers.ToListAsync();
        }

        public async Task<Squeezer?> GetByIdAsync(int id)
        {
            return await _context.Squeezers.FindAsync(id);
        }

        public async Task UpdateAsync(Squeezer squeezer)
        {
            _context.Squeezers.Update(squeezer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var squeezer = await _context.Squeezers.FindAsync(id);
            if (squeezer != null)
            {
                _context.Squeezers.Remove(squeezer);
                await _context.SaveChangesAsync();  
            }
        }
    }
}
