namespace FusionTech.src.Entity
{
    public class VideoGame
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public DateTime YearOfRelease { get; set; }
        public int TotalRating { get; set; }
        public int PublisherId { get; set; }
        public string? GamePicturePath { get; set; }
    }
}
