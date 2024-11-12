namespace FusionTech.src.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class VideoGamesVersionController : ControllerBase
    {
        protected readonly IVideoGameVersionService _versionService;

        public VideoGamesVersionController(IVideoGameVersionService videoGameVersionService)
        {
            _versionService = videoGameVersionService;
        }

        [HttpPost]
        [Authorize(Policy = "EmployeeOrAdmin")]
        public async Task<ActionResult<VideoGameVersionReadDto>> CreateOne(
            [FromBody] VideoGameVersionCreateDto createDto
        )
        {
            var videoGameVersionCreated = await _versionService.CreateOneAsync(createDto);
            return Created(
                $"api/v1/categories/{videoGameVersionCreated.VideoGameVersionId}",
                videoGameVersionCreated
            );
            // return Ok(categoryCreated);
        }

        [HttpGet]
        public async Task<ActionResult<VideoGameVersionReadDto>> GetVersion()
        {
            var versionList = await _versionService.GetAllAsync();
            return Ok(versionList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<VideoGameVersionReadDto>> GetVersionByIdAsync(
            [FromRoute] Guid Id
        )
        {
            var version = await _versionService.GetVersionByIdAsync(Id);
            return Ok(version);
        }

        [HttpDelete("{Id}")]
        [Authorize(Policy = "EmployeeOrAdmin")]
        public async Task<ActionResult<VideoGameVersionReadDto>> DeleteOneAsync([FromRoute] Guid Id)
        {
            var version = await _versionService.GetVersionByIdAsync(Id);
            await _versionService.DeleteOneAsync(version.VideoGameVersionId);
            return Ok(version);
        }

        [Authorize(Policy = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneAsync(
            Guid id,
            VideoGameVersionUpdateDto updateGameVersion
        )
        {
            var isUpdated = await _versionService.UpdateOneAsync(id, updateGameVersion);

            return NoContent();
        }
        
    }
}
