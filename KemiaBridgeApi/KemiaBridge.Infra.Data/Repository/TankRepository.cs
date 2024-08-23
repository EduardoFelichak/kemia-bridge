using KemiaBridge.Domain.Entities;
using KemiaBridge.Domain.Enums;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class TankRepository : ITankRepository
    {
        private readonly ConnectionContext _context;

        public TankRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tank tank)
        {
            _context.Tanks.Add(tank);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tank>> GetAllAsync()
        {
            return await _context.Tanks.ToListAsync();
        }

        public async Task<Tank?> GetByIdAsync(int id)
        {
            return await _context.Tanks.FindAsync(id);
        }

        public async Task<IEnumerable<Tank>> GetByTypeAsync(TankType tankType)
        {
            return await _context.Tanks
                .Where(t => t.Type == tankType)
                .ToListAsync();
        }

        public async Task UpdateAsync(Tank tank)
        {
            _context.Tanks.Update(tank);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tank = await _context.Tanks.FindAsync(id);
            if (tank != null)
            {
                _context.Tanks.Remove(tank);
                await _context.SaveChangesAsync();
            }
        }
    }
}
