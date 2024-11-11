namespace FusionTech.src.Repository
{
    public class VideoGameInfoRepository
    {
        protected DbSet<VideoGameInfo> _videoGameInfos;
        protected DatabaseContext _databaseContext;

        public VideoGameInfoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _videoGameInfos = databaseContext.Set<VideoGameInfo>();
        }

        // Get a video game by ID
        public async Task<VideoGameInfo?> GetByIdAsync(Guid id)
        {
            return await _videoGameInfos
                .Include(v => v.VideoGameVersions)
                .Include(v => v.Categories)
                .Include(v => v.GameStudios)
                .FirstOrDefaultAsync(v => v.VideoGameInfoId == id);
        }

        public async Task<List<VideoGameInfo>> GetVideoGameVersionByIdAsync(Guid id)
        {
            return await _videoGameInfos
                .Include(vi => vi.VideoGameVersions)
                .Where(vi => vi.VideoGameInfoId == id)
                .ToListAsync();
        }

        public async Task<List<VideoGameRatingReadDto>> GetVideoGameRatingsByIdAsync(Guid id)
        {
            return await _videoGameInfos
                .Where(vi => vi.VideoGameInfoId == id)
                .SelectMany(vi => vi.RatedBies)
                .Select(rb => new VideoGameRatingReadDto
                {
                    Rating = rb.Rating,
                    Comment = rb.Comment,
                    PersonId = rb.Customer.PersonId,
                    PersonName = rb.Customer.PersonName,
                    ProfilePicturePath = rb.Customer.ProfilePicturePath,
                })
                .ToListAsync();
        }

        // Create a new video game
        public async Task<VideoGameInfo> CreateOneAsync(VideoGameInfo newGameInfo)
        {
            foreach (var category in newGameInfo.Categories)
                _databaseContext.Attach(category);

            foreach (var studio in newGameInfo.GameStudios)
                _databaseContext.Attach(studio);

            await _videoGameInfos.AddAsync(newGameInfo);
            await _databaseContext.SaveChangesAsync();
            return newGameInfo;
        }

        //Get all video games
        public async Task<List<VideoGameInfo>> GetAllAsync()
        {
            return await _videoGameInfos.ToListAsync();
        }

        // Update an existing video game
        public async Task<bool> UpdateOnAsync(VideoGameInfo updateGameInfo)
        {
            _videoGameInfos.Update(updateGameInfo);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        // Delete a video game
        public async Task<bool> DeleteOnAsync(VideoGameInfo gameInfo)
        {
            try
            {
                _videoGameInfos.Remove(gameInfo);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public async Task<List<VideoGameInfo>> GetAllWithVersionAsync()
        {
            return await _videoGameInfos.Include(v => v.VideoGameVersions).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _videoGameInfos.CountAsync();
        }
    }
}
