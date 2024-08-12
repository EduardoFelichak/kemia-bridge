using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper           _mapper;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
            _mapper            = MapperConfig.GetMapper<StationProfile>();
        }

        public async Task AddAsync(StationDto stationDto)
        {
            var station = _mapper.Map<Station>(stationDto);
            await _stationRepository.AddAsync( station );
            stationDto.SetNewId(station.StationId);
        }

        public Task<IEnumerable<Station>> GetAllAsync()
        {
            return _stationRepository.GetAllAsync();
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _stationRepository.GetByIdAsync( id );
        }

        public async Task UpdateAsync(int id, StationDto stationDto)
        {
            var station = await _stationRepository.GetByIdAsync( id );
            if (station == null)
                throw new KeyNotFoundException($"Station with Id {id} not found");

            _mapper.Map(stationDto, station);
            await _stationRepository.UpdateAsync( station );
        }

        public async Task DeleteAsync(int id)
        {
            await _stationRepository.DeleteAsync( id );
        }
    }
}
