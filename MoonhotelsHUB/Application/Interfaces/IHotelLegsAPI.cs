using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Application
{
    public interface IHotelLegsAPI
    {
        Task<HotelLegsResponse> Search(HotelLegsRequest request);
    }
}
