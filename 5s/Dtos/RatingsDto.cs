namespace _5s.Dtos
{
    public class RatingsDto
    {
        public int Id { get; set; }
        public float Sort { get; set; }
        public float SetInOrder { get; set; }
        public float Shine { get; set; }
        public float Standarize { get; set; }
        public float Sustain { get; set; }
        public float Security { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateModified { get; set; }
        public int SpaceId { get; set; }
    }
}
