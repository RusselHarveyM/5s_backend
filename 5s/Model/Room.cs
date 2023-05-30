namespace _5s.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string? RoomNumber { get; set; }
        public List<byte[]> Image { get; set; }
    }
}
