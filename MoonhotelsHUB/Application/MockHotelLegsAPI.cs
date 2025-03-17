using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Application
{
    public class MockHotelLegsAPI : IHotelLegsAPI
    {
        public async Task<HotelLegsResponse> Search(HotelLegsRequest request)
        {
            return new HotelLegsResponse()
            {
                Results = new List<HotelLegsResult>()
                {
                    new HotelLegsResult()
                    {
                        Room = 1,
                        Meal = 1,
                        CanCancel = false,
                        Price = 123.48m,
                    },
                    new HotelLegsResult()
                    {
                        Room = 1,
                        Meal = 1,
                        CanCancel = true,
                        Price = 150.00m,
                    },
                    new HotelLegsResult()
                    {
                        Room = 2,
                        Meal = 1,
                        CanCancel = false,
                        Price = 148.25m,
                    },
                    new HotelLegsResult()
                    {
                        Room = 2,
                        Meal = 2,
                        CanCancel = false,
                        Price = 165.38m,
                    }
                }
            };
        }
    }
}
