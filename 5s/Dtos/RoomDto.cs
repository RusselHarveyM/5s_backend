namespace _5s.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string? RoomNumber { get; set; }
        public byte[]? Image { get; set; }
        public string Status { get; set; }
    }
}
