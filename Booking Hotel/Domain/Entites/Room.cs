using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Domain.Entites
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
        public Status Status { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
