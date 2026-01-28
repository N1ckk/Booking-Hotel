using AutoMapper;
using Booking_Hotel.Application.DTOs;
using Booking_Hotel.Domain.Entites;

namespace Booking_Hotel.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.PassHash, 
                opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, 
                opt => opt.MapFrom(_ => UserRole.Guest))
                .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, 
                opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
