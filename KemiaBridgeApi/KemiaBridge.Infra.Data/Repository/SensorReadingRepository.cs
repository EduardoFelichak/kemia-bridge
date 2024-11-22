using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class SensorReadingRepository : ISensorReadingRepository
    {
        private readonly ConnectionContext _context;

        public SensorReadingRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SensorReading sensorReading)
        {
            _context.SensorsReading.Add(sensorReading);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sensorReading = await _context.SensorsReading.FindAsync(id);
            if (sensorReading != null) 
            { 
                _context.SensorsReading.Remove(sensorReading);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SensorReading>> GetAllAsync()
        {
            return await _context.SensorsReading.ToListAsync();
        }

        public async Task<SensorReading?> GetByIdAsync(int id)
        {
            return await _context.SensorsReading.FindAsync(id);
        }

        public async Task UpdateAsync(SensorReading sensorReading)
        {
            _context.SensorsReading.Update(sensorReading);
            await _context.SaveChangesAsync();
        }
    }
}
