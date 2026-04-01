using Booking_Hotel.Domain.Entites;
namespace Booking_Hotel.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User dto);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(string name);
        Task<IReadOnlyList<User>> GetAllAsync();
    }
}
