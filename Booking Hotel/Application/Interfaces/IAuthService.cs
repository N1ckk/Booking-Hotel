using Booking_Hotel.Application.DTOs;
namespace Booking_Hotel.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
