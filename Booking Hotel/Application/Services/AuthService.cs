using Booking_Hotel.Application.DTOs;
using Booking_Hotel.Application.Interfaces;
using Booking_Hotel.Domain.Interfaces;
using System.Security;
namespace Booking_Hotel.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _jwtGenerator;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher hasher,
            IJwtTokenGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByNameAsync(dto.Name);

            if(user==null)
            {
                throw new KeyNotFoundException($"User not found.");
            }

            if (!_hasher.Verify(dto.Password, user.PassHash))
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            var token = _jwtGenerator.GenerateToken(user);

            // <-- Логируем токен в консоль
            Console.WriteLine($"Generated JWT: {token}");

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                UserName = user.Name,
                Role = user.Role.ToString()
            };
        }
    }
}
