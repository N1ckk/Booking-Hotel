using Booking_Hotel.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Application.DTOs
{
    public class RoomUpdateDto
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public RoomType Type { get; set; }
        [Required]
        public decimal PricePerNight { get; set; }
        [Required]
        public Status Status { get; set; }

    }
}
