using Booking_Hotel.Application.DTOs;
using Booking_Hotel.Domain.Interfaces;
using Booking_Hotel.Domain.Entites;
using AutoMapper;

namespace Booking_Hotel.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher hasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hasher = hasher;
        }

        public async Task<UserDto> AddAsync(UserRegisterDto dto)
        {
            if(dto==null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var user = _mapper.Map<User>(dto);

            user.PassHash = _hasher.Hash(dto.Password);

            await _userRepository.RegisterAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            
            if (user==null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);

            if(user==null)
            {
                throw new KeyNotFoundException($"User with name {name} not found.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IReadOnlyList<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if(users==null)
            {
                return new List<UserDto>();
            }
            var usersDto = _mapper.Map<IReadOnlyList<UserDto>>(users);

            return usersDto;
        }
    }
}
