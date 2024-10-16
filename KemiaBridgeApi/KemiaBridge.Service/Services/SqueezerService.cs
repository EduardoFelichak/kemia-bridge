using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class SqueezerService : ISqueezerService
    {
        private readonly ISqueezerRepository _squeezerRepository;
        private readonly IMapper             _mapper;

        public SqueezerService(ISqueezerRepository squeezerRepository)
        {
            _squeezerRepository = squeezerRepository;
            _mapper             = MapperConfig.GetMapper<SqueezerProfile>();
        }

        public async Task AddAsync(SqueezerDto squeezerDto)
        {
            var squeezer = _mapper.Map<Squeezer>(squeezerDto);
            await _squeezerRepository.AddAsync( squeezer );
            squeezerDto.SetNewId(squeezer.SqueezerId);
        }

        public async Task<IEnumerable<Squeezer>> GetAllAsync()
        {
            return await _squeezerRepository.GetAllAsync();
        }

        public async Task<Squeezer?> GetByIdAsync(int id)
        {
            return await _squeezerRepository.GetByIdAsync( id );
        }

        public async Task UpdateAsync(int id, SqueezerDto squeezerDto)
        {
            var squeezer = await _squeezerRepository.GetByIdAsync(id);
            if ( squeezer == null )
                throw new KeyNotFoundException($"Squeezer with Id {id} not found");
            _mapper.Map(squeezerDto, squeezer);
            await _squeezerRepository.UpdateAsync( squeezer );
        }

        public async Task DeleteAsync(int id)
        {
            await _squeezerRepository.DeleteAsync( id );
        }
    }
}
