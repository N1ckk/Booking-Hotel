using Booking_Hotel.Domain.Entites;

namespace Booking_Hotel.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(int id);
        Task<IReadOnlyList<Room>> GetAllAsync();
        Task<Room> AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int id);
    }
}
