namespace FusionTech.src.DTO
{
    public class VideoGameVersionDTO
    {
        public class VideoGameVersionCreateDto
        {
            public Guid VideoGameInfoId { get; set; }
            public Guid GameConsoleId { get; set; }
            public float Price { get; set; }
        }

        public class VideoGameVersionCreateWithoutIdDto
        {
            public Guid GameConsoleId { get; set; }

            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
            public float Price { get; set; }
        }

        public class VideoGameVersionUpdateDto
        {
            public Guid? GameConsoleId { get; set; }
            public float? Price { get; set; }
        }

        public class VideoGameVersionReadDto
        {
            public Guid VideoGameVersionId { get; set; }
            public Guid VideoGameInfoId { get; set; }
            public float Price { get; set; }
            public Guid GameConsoleId { get; set; }
        }

        public class VideoGameVersionSimpleReadDto
        {
            public Guid VideoGameVersionId { get; set; }
            public double Price { get; set; }
            public Guid GameConsoleId { get; set; }
        }
    }
}
