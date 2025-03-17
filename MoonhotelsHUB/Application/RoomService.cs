using MoonhotelsHUB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoonhotelsHUB.Application
{
    public class RoomService : IRoomService
    {
        private readonly IEnumerable<IRoomProvider> _providers;

        public RoomService(IEnumerable<IRoomProvider> providers)
        {
            _providers = providers;
        }

        public async Task<HubSearchResponse> SearchAsync(HubSearchRequest request)
        {
            var tasks = _providers.Select(connector => connector.Search(request));
            var responses = await Task.WhenAll(tasks);

            var aggregatedResponse = new HubSearchResponse();

            // Aggregate in a single response avoiding duplicated rooms
            foreach (var response in responses)
            {
                foreach (var room in response.Rooms)
                {
                    var existingRoom = aggregatedResponse.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
                    if (existingRoom == null)
                    {
                        aggregatedResponse.Rooms.Add(room);
                    }
                    else
                    {
                        
                        existingRoom.Rates.AddRange(room.Rates);
                    }
                }
            }

            // Clean duplicated rates
            foreach (var room in aggregatedResponse.Rooms)
            {
                room.Rates = room.Rates
                    .DistinctBy(r => new { r.MealPlanId, r.IsCancellable, r.Price })
                    .ToList();
            }

            return aggregatedResponse;
        }
    }
}
