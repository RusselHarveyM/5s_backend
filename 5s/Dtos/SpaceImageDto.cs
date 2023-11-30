namespace _5s.Dtos
{
    public class SpaceImageDto
    {
        public int Id { get; set; }
        public int SpaceId { get; set; }
        public byte[]? Image { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
