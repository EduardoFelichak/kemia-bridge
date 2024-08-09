using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Infra.Data.Repository.Abstract
{
    public interface ILegalPersonRepository
    {
        Task AddAsync(LegalPerson legalPerson);
        Task<IEnumerable<LegalPerson>> GetAllAsync();
        Task<LegalPerson?> GetByIdAsync(int id);
        Task UpdateAsync(LegalPerson legalPerson);
        Task DeleteAsync(int id);
    }
}
