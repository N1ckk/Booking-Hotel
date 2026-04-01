using Booking_Hotel.Domain.Interfaces;
using System.Runtime.CompilerServices;
using Booking_Hotel.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Booking_Hotel.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u=> u.Id == id);
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
