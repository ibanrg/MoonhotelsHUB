using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Application
{
    public interface IRoomProvider
    {
        Task<HubSearchResponse> Search(HubSearchRequest request);
    }
}
