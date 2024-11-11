namespace FusionTech.src.Entity
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<VideoGameInfo> VideoGameInfos { get; set; } =
            new List<VideoGameInfo>();
    }
}
