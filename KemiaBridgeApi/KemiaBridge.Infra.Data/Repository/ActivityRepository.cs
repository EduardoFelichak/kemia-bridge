using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ConnectionContext _context;

        public ActivityRepository(ConnectionContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetByStatus(int status)
        {
            return await _context.Activities
                .Where(a => a.Status == status)
                .ToListAsync();
        }

        public async Task UpdateAsync(Activity activity)
        {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null) 
            { 
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
