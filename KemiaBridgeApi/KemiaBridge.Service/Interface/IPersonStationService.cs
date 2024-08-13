using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IPersonStationService
    {
        Task AddAsync(PersonStationDto personStationDto);
        Task<IEnumerable<PersonStation>> GetAllAsync();
        Task<PersonStation?> GetByIdAsync(int id);
        Task DeleteAsync(PersonStationDto personStationDto);
    }
}
