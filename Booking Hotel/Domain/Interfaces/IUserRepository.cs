using Booking_Hotel.Domain.Entites;
namespace Booking_Hotel.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User dto);
        Task<User> GetByIdAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
    }
}
