using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class StepRepository : IStepRepository
    {
        private readonly ConnectionContext _context;

        public StepRepository(ConnectionContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(Step step)
        {
            _context.Steps.Add(step);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            return await _context.Steps.ToListAsync();
        }

        public async Task<Step?> GetByIdAsync(int id)
        {
            return await _context.Steps
                                  .FirstOrDefaultAsync(s => s.StepId == id);
        }

        public async Task UpdateAsync(Step step)
        {
            _context.Steps.Update(step);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var step = await _context.Steps.FindAsync(id);
            if (step != null)
            {
                _context.Steps.Remove(step);
                await _context.SaveChangesAsync();
            }
        }

    }
}
