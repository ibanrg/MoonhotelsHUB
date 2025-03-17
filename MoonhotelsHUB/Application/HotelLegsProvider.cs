using AutoMapper;
using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Application
{
    public class HotelLegsProvider : IRoomProvider
    {
        private IHotelLegsAPI _apiService;
        private IMapper _mapper;

        public HotelLegsProvider(IHotelLegsAPI apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<HubSearchResponse> Search(HubSearchRequest request)
        {
            var response = await _apiService.Search(_mapper.Map<HotelLegsRequest>(request));
            return MapResponse(response);
        }

        public HubSearchResponse MapResponse(HotelLegsResponse response)
        {
            var hubResponse = new HubSearchResponse();

            foreach(var room in response.Results)
            {
                var existingRoom = hubResponse.Rooms.FirstOrDefault(r => r.RoomId == room.Room);
                if (existingRoom == null)
                {
                    hubResponse.Rooms.Add(new HubRoom() 
                    { 
                        RoomId = room.Room,
                        Rates = new List<HubRate>()
                        {
                            new HubRate()
                            {
                                MealPlanId = room.Meal,
                                IsCancellable = room.CanCancel,
                                Price = room.Price
                            }
                        }
                    });
                }
                else
                {
                    existingRoom.Rates.Add(new HubRate()
                    {
                        MealPlanId = room.Meal,
                        IsCancellable = room.CanCancel,
                        Price = room.Price
                    });
                }
            }

            return hubResponse;
        }
    }
}
