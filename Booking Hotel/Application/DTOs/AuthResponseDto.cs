namespace Booking_Hotel.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
