using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Context;

namespace KemiaBridge.Infra.Data.Repository
{
    public class PhysicPersonRepository : IPhysicPersonRepository
    {
        private readonly ConnectionContext _context;

        public PhysicPersonRepository(ConnectionContext context)
        { 
            _context = context;
        }

        public Task AddAsync(PhysicPerson physicPerson)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhysicPerson>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PhysicPerson?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PhysicPerson physicPerson)
        {
            throw new NotImplementedException();
        }
    }
}
