using Microsoft.AspNetCore.Mvc;
using MoonhotelsHUB.Application;
using MoonhotelsHUB.Models;

namespace MoonhotelsHUB.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _service;

    public RoomController(IRoomService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<HubSearchResponse> Get()
    {
        return await _service.SearchAsync(new HubSearchRequest()
        {
            HotelId = 1,
            CheckIn = DateTime.Parse("2018-10-20"),
            CheckOut = DateTime.Parse("2018-10-25"),
            NumberOfGuests = 3,
            NumberOfRooms = 2,
            Currency = "EUR"
        });
    }
}
