namespace _5s.Model
{
    public class SpaceImage
    {
        public int Id { get; set; }
        public int SpaceId { get; set; } 
        public byte[]? Image { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
