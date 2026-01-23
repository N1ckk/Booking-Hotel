using Microsoft.EntityFrameworkCore;
using Booking_Hotel.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Booking_Hotel.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User>  Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne<User>(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<Room>()
                .HasIndex(r => r.Number)
                .IsUnique();

            modelBuilder.Entity<Room>()
                .Property(r => r.PricePerNight)
                .HasPrecision(18, 2);
        }
    }
}
