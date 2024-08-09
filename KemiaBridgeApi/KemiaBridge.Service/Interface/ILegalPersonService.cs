using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface ILegalPersonService
    {
        Task AddAsync(LegalPersonDto legalPersonDto);
        Task<IEnumerable<LegalPerson>> GetAllAsync();
        Task<LegalPerson?> GetByIdAsync(int id);
        Task UpdateAsync(int id, LegalPersonDto legalPersonDto);
        Task DeleteAsync(int id);
    }
}
