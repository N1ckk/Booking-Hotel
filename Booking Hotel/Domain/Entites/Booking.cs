using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Booking_Hotel.Domain.Entites
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int RoomId { get; set; }
        [JsonIgnore]
        public Room? Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public StatusBooking Status { get; set; }
    }
}
