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
            
        public StationService(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper            = mapper;
        }

        public async Task AddAsync(StationDto stationDto)
        {
            var station = _mapper.Map<Station>(stationDto);
            await _stationRepository.AddAsync( station );
            stationDto.SetNewId(station.StationId);
        }

        public async Task<IEnumerable<StationDto>> GetAllAsync()
        {
            var stations = await _stationRepository.GetAllAsync();

            var stationDtos = _mapper.Map<List<StationDto>>(stations);

            return stationDtos.AsEnumerable();
        }

        public async Task<StationDto?> GetByIdAsync(int id)
        {
            var station = await _stationRepository.GetByIdAsync( id );

            return _mapper.Map<StationDto>(station);
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
