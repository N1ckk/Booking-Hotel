using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Domain.Entites
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassHash { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
