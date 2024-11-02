using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;

namespace KemiaBridge.Service.Interface
{
    public interface IStationService
    {
        Task AddAsync(StationDto stationDto);
        Task<IEnumerable<StationDto?>> GetAllAsync();
        Task<StationDto?> GetByIdAsync(int id);
        Task UpdateAsync(int id, StationDto stationDto);
        Task DeleteAsync(int id);
    }
}
