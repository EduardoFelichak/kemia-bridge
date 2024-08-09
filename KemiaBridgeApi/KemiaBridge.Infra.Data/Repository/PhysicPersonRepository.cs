using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Repository
{
    public class PhysicPersonRepository : IPhysicPersonRepository
    {
        private readonly ConnectionContext _context;

        public PhysicPersonRepository(ConnectionContext context)
        { 
            _context = context;
        }

        public async Task AddAsync(PhysicPerson physicPerson)
        {
            _context.PhysicPeople.Add(physicPerson);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhysicPerson>> GetAllAsync()
        {
            return await _context.PhysicPeople.ToListAsync();   
        }

        public async Task<PhysicPerson?> GetByIdAsync(int id)
        {
            return await _context.PhysicPeople
                                 .FirstOrDefaultAsync(pp => pp.PersonId == id);   
        }

        public Task UpdateAsync(PhysicPerson physicPerson)
        {
            _context.PhysicPeople.Update(physicPerson);
            return _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var physicPerson = await _context.PhysicPeople.FindAsync(id);
            if (physicPerson != null)
            {
                _context.PhysicPeople.Remove(physicPerson); 
                await _context.SaveChangesAsync();
            }
        }
    }
}
