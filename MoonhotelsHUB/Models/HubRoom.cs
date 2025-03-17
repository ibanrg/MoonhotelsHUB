namespace MoonhotelsHUB.Models
{
    public class HubRoom
    {
        public int RoomId { get; set; }
        public List<HubRate> Rates { get; set; } = new List<HubRate>();
    }
}
