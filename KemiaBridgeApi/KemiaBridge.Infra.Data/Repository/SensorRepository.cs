using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ConnectionContext _context;

        public SensorRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);    
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Sensor>> GetAllAsync()
        {
            var sensors = await _context.Sensors.ToListAsync();
            return sensors;
        }

        public async Task<Sensor?> GetByIdAsync(int id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task<IEnumerable<Sensor>> GetByStepAsync(int id)
        {
            return await _context.Sensors
                                 .Where(s => s.StepId == id)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Sensor sensor)
        {
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();
        }
    }
}
