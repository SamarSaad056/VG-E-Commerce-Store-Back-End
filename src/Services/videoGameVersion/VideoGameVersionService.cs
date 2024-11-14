namespace FusionTech.src.Services.videoGameVersion
{
    public class VideoGameVersionService : IVideoGameVersionService
    {
        protected readonly VideoGameVersionRepository _videoGameVersionRepo;
        protected readonly IMapper _mapper;

        public VideoGameVersionService(
            VideoGameVersionRepository videoGameVersionRepository,
            IMapper mapper
        )
        {
            _videoGameVersionRepo = videoGameVersionRepository;
            _mapper = mapper;
        }

        public async Task<VideoGameVersionReadDto> CreateOneAsync(
            VideoGameVersionCreateDto createGameVersion
        )
        {
            var videoGame = _mapper.Map<VideoGameVersionCreateDto, VideoGameVersion>(
                createGameVersion
            );
            var createdGameVersion = await _videoGameVersionRepo.CreateOneAsync(videoGame);
            if (createdGameVersion == null)
            {
                throw CustomException.InternalError("Failed to create the video game version.");
            }
            return _mapper.Map<VideoGameVersion, VideoGameVersionReadDto>(createdGameVersion);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundGameVersion = await _videoGameVersionRepo.GetVersionByIdAsync(id);
            if (foundGameVersion == null)
            {
                throw CustomException.NotFound($"Video game version with ID {id} not found.");
            }

            return await _videoGameVersionRepo.DeleteOneAsync(foundGameVersion);
        }

        public async Task<List<VideoGameVersionReadDto>> GetAllAsync()
        {
            var videoGameList = await _videoGameVersionRepo.GetAllAsync();
            if (videoGameList == null || videoGameList.Count == 0)
            {
                throw CustomException.NotFound("No video game versions found.");
            }

            return _mapper.Map<List<VideoGameVersion>, List<VideoGameVersionReadDto>>(
                videoGameList
            );
        }

        public async Task<VideoGameVersionReadDto> GetVersionByIdAsync(Guid id)
        {
            var foundGameVersion = await _videoGameVersionRepo.GetVersionByIdAsync(id);
            if (foundGameVersion == null)
            {
                throw CustomException.NotFound($"Video game version with ID {id} not found.");
            }
            return _mapper.Map<VideoGameVersion, VideoGameVersionReadDto>(foundGameVersion);
        }

        public async Task<bool> UpdateOneAsync(Guid id, VideoGameVersionUpdateDto updateGameVersion)
        {
            var foundGameVersion = await _videoGameVersionRepo.GetVersionByIdAsync(id);
            if (foundGameVersion == null)
            {
                throw CustomException.NotFound($"Video game version with ID {id} not found.");
            }
            _mapper.Map(updateGameVersion, foundGameVersion);
            bool isUpdated = await _videoGameVersionRepo.UpdateOneAsync(foundGameVersion);
            if (!isUpdated)
            {
                throw CustomException.InternalError("Failed to update the video game version.");
            }
            return isUpdated;
        }
    }
}
