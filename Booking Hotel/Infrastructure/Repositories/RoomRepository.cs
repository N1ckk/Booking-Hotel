using Booking_Hotel.Domain.Interfaces;
using Booking_Hotel.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Booking_Hotel.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Id==id);
        }

        public async Task<IReadOnlyList<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task UpdateRoomAsync(Room r)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _context.Rooms.Where(r => r.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
