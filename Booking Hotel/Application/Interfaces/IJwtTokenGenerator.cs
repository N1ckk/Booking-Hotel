using Booking_Hotel.Domain.Entites;
namespace Booking_Hotel.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
