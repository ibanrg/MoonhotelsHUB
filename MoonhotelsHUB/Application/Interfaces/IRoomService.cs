using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Application
{
    public interface IRoomService
    {
        Task<HubSearchResponse> SearchAsync(HubSearchRequest request);
    }
}
