using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemiaBridge.Service.Services
{
    public class StepService : IStepService
    {
        private readonly IStepRepository _stepRepository;
        private readonly IMapper         _mapper;

        public StepService(IStepRepository stepRepository, IMapper mapper)
        {
            _stepRepository = stepRepository;
            _mapper         = mapper;
        }

        public async Task AddAsync(StepDto stepDto)
        {
            var step = _mapper.Map<Step>(stepDto);
            await _stepRepository.AddAsync( step );
            stepDto.SetNewId( step.StepId );
        }

        public async Task<IEnumerable<StepDto>> GetAllAsync()
        {
            var steps = await _stepRepository.GetAllAsync();

            var stepDtos = _mapper.Map<List<StepDto>>(steps);

            return stepDtos.AsEnumerable();
        }

        public async Task<StepDto?> GetByIdAsync(int id)
        {
            var step = await _stepRepository.GetByIdAsync( id );

            return _mapper.Map<StepDto>(step);
        }

        public async Task UpdateAsync(int id, StepDto stepDto)
        {
            var step = await _stepRepository.GetByIdAsync( id );
            if ( step == null )
                throw new KeyNotFoundException($"Step with Id {id} not found");

            _mapper.Map(stepDto, step);
            await _stepRepository.UpdateAsync( step );
        }

        public async Task DeleteAsync(int id)
        {
            await _stepRepository.DeleteAsync( id );
        }

        public async Task AddManyAsync(IEnumerable<StepDto> stepsDto)
        {
            foreach (var stepDto in stepsDto)
            {
                var step = _mapper.Map<Step>(stepDto);
                await _stepRepository.AddAsync(step);
                stepDto.SetNewId(step.StepId);
            }
        }
    }
}
