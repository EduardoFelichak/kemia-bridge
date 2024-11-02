using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;

namespace KemiaBridge.Service.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper             _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            await _activityRepository.AddAsync(activity);
            activityDto.SetNewId(activity.ActivityId);
        }

        public async Task<IEnumerable<ActivityDto>> GetAllAsync()
        {
            var activities = await _activityRepository.GetAllAsync();

            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);

            return activityDtos.AsEnumerable();
        }

        public async Task<ActivityDto?> GetByIdAsync(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);

            return _mapper.Map<ActivityDto>(activity);
        }

        public async Task<IEnumerable<ActivityDto>> GetByStatusAsync(int status)
        {
            var activities = await _activityRepository.GetByStatus(status);

            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);

            return activityDtos.AsEnumerable();
        }

        public async Task UpdateAsync(int id, ActivityDto activityDto)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null)
                throw new KeyNotFoundException($"Activity with Id {id} not found");

            _mapper.Map(activityDto, activity);
            await _activityRepository.UpdateAsync(activity);
        }

        public async Task DeleteAsync(int id)
        {
            await _activityRepository.DeleteAsync(id);
        }
    }
}
