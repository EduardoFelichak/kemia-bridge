using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly ConnectionContext _context;

        public StationRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Station station)
        {
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _context.Stations
                                 .FirstOrDefaultAsync(s => s.StationId == id); 
        }

        public Task UpdateAsync(Station station)
        {
            _context.Stations.Update(station);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station != null) 
            {
                _context.Stations.Remove(station);
                await _context.SaveChangesAsync();
            }
        }
    }
}
