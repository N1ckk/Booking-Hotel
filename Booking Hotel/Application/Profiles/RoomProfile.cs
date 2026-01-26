using AutoMapper;
using Booking_Hotel.Application.DTOs;
using Booking_Hotel.Domain.Entites;
namespace Booking_Hotel.Application.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomCreateDto, Room>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());

            CreateMap<RoomUpdateDto, Room>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());
        }
    }
}
