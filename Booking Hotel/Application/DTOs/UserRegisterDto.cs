using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Application.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
