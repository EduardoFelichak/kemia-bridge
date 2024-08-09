using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        private readonly ConnectionContext _context;

        public LegalPersonRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LegalPerson legalPerson)
        {
            _context.LegalPeople.Add(legalPerson);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<LegalPerson>> GetAllAsync()
        {
            return await _context.LegalPeople.ToListAsync();    
        }

        public async Task<LegalPerson?> GetByIdAsync(int id)
        {
            return await _context.LegalPeople
                                 .FirstOrDefaultAsync(pp => pp.PersonId == id);   
        }

        public async Task UpdateAsync(LegalPerson legalPerson)
        {
            _context.LegalPeople.Update(legalPerson);   
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var legalPerson = await _context.LegalPeople.FindAsync(id);
            if (legalPerson != null)
            {
                _context.LegalPeople.Remove(legalPerson);
                await _context.SaveChangesAsync();
            }
        }
    }
}
