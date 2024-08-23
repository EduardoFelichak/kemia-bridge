using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class PersonStationRepository : IPersonStationRepository
    {
        private readonly ConnectionContext _context;

        public PersonStationRepository(ConnectionContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(PersonStation personStation)
        {
            _context.PersonStations.Add(personStation);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<PersonStation>> GetAllAsync()
        {
            return await _context.PersonStations.ToListAsync();
        }

        public async Task<PersonStation?> GetByIdAsync(int id)
        {
            return await _context.PersonStations.FindAsync(id);
        }

        public async Task DeleteAsync(PersonStation personStation)
        {
            _context.PersonStations.Remove(personStation);
            await _context.SaveChangesAsync();
        }
    }
}
