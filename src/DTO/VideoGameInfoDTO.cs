namespace FusionTech.src.DTO
{
    public class VideoGameInfoDTO
    {
        public class VideoGameInfoCreateDto
        {
            [Required(ErrorMessage = "Game name is required.")]
            [StringLength(100, ErrorMessage = "Game name cannot exceed 100 characters.")]
            public string? GameName { get; set; }

            [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
            public string? Description { get; set; }

            [Required(ErrorMessage = "Year of release is required.")]
            [DataType(DataType.Date)]
            public string? YearOfRelease { get; set; }

            [Range(1, 5, ErrorMessage = "Total rating must be between 1 and 5.")]
            public int TotalRating { get; set; }
            public Guid PublisherId { get; set; }
            public string? GamePicturePath { get; set; }
            public ICollection<Guid> CategoryIds { get; set; } = [];
            public ICollection<Guid> GameStudioIds { get; set; } = [];
            public ICollection<VideoGameVersionCreateWithoutIdDto> VideoGameVersions { get; set; } =
                [];
        }

        public class VideoGameInfoUpdateDto
        {
            [StringLength(100, ErrorMessage = "Game name cannot exceed 100 characters.")]
            public string? GameName { get; set; }

            [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
            public string? Description { get; set; }

            [DataType(DataType.Date)]
            public string? YearOfRelease { get; set; }

            [Range(1, 5, ErrorMessage = "Total rating must be between 1 and 5.")]
            public int? TotalRating { get; set; }
            public Guid? PublisherId { get; set; }
            public string? GamePicturePath { get; set; }
        }

        public class VideoGameInfoReadDto
        {
            public Guid VideoGameInfoId { get; set; }

            public string? GameName { get; set; }

            public string? Description { get; set; }

            public string? YearOfRelease { get; set; }

            public int TotalRating { get; set; }

            public Guid PublisherId { get; set; }

            public string? GamePicturePath { get; set; }

            // retrieve a video game's details
            // public List<VideoGameVersionReadDto> VideoGameVersions { get; set; } =
            //     new List<VideoGameVersionDTO.VideoGameVersionReadDto>();
        }

        public class VideoGameDetailedDto : VideoGameInfoReadDto
        {
            public ICollection<VideoGameVersionSimpleReadDto> VideoGameVersions { get; set; }
            public ICollection<StudioReadDTO> GameStudios { get; set; }
            public ICollection<CategoryBasicDto> Categories { get; set; }
            public ICollection<GameConsole> Consoles { get; set; }
        }

        public class VideoGameWithVersionDto
        {
            public Guid VideoGameInfoId { get; set; }

            public string? GameName { get; set; }

            public string? Description { get; set; }

            public string? YearOfRelease { get; set; }

            public int TotalRating { get; set; }

            public Guid PublisherId { get; set; }

            public string? GamePicturePath { get; set; }

            public ICollection<VideoGameVersionSimpleReadDto> VideoGameVersions { get; set; }
        }

        public class VideoGamesInfoListDto
        {
            public List<VideoGameInfoReadDto> VideoGamesInfos { get; set; }
            public int TotalCount { get; set; }
        }

        public class VideoGamesInfoWithVersionListDto
        {
            public List<VideoGameWithVersionDto> VideoGamesInfos { get; set; } = [];
            public int TotalCount { get; set; }
        }
    }
}
