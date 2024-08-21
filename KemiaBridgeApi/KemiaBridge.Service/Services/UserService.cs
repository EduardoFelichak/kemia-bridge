using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper         _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = MapperConfig.GetMapper<UserProfile>();
        }

        public async Task AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            userDto.SetNewId(user.UserId);
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with Id {id} not found");
            _mapper.Map(userDto, user);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> SignInAsync(string email, string password)
        {
            return await _userRepository.SignInAsync(email, password);
        }
    }
}
