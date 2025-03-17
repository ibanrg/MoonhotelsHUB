using AutoMapper;
using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HubSearchRequest, HotelLegsRequest>()
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.NumberOfRooms))
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.NumberOfGuests))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.HotelId))
                .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => src.CheckIn))
                .ForMember(dest => dest.NumberOfNights, opt => opt.MapFrom(src => (src.CheckOut - src.CheckIn).TotalDays));
        }
    }
}
