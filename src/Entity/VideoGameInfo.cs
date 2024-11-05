namespace FusionTech.src.Entity
{
    public class VideoGameInfo
    {
        public Guid VideoGameInfoId { get; set; }
        public string? GameName { get; set; }
        public string? Description { get; set; }
        public string? YearOfRelease { get; set; }
        public int TotalRating { get; set; }
        public Guid PublisherId { get; set; }
        public string? GamePicturePath { get; set; }
        public ICollection<GameStudio> GameStudios { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<VideoGameVersion> VideoGameVersions { get; set; }
        public ICollection<GameConsole> Consoles { get; set; }
        public ICollection<RatedBy> RatedBies { get; set; }
    }
}
