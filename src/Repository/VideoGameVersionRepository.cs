namespace FusionTech.src.Repository
{
    public class VideoGameVersionRepository
    {
        protected DbSet<VideoGameVersion> _videoGameVersions;
        protected DatabaseContext _databaseContext;

        public VideoGameVersionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _videoGameVersions = databaseContext.Set<VideoGameVersion>();
        }

        // Get a video game by ID
        public async Task<VideoGameVersion> GetVersionByIdAsync(Guid id)
        {
            return await _videoGameVersions.FindAsync(id);
        }

        // Create a new video game
        public async Task<VideoGameVersion> CreateOneAsync(VideoGameVersion newGameVersion)
        {
            await _videoGameVersions.AddAsync(newGameVersion);
            await _databaseContext.SaveChangesAsync();
            return newGameVersion;
        }

        // Get all video games
        public async Task<List<VideoGameVersion>> GetAllAsync()
        {
            return await _videoGameVersions.ToListAsync();
        }

        // Update an existing video game
        public async Task<bool> UpdateOneAsync(VideoGameVersion updateGameVersion)
        {
            _videoGameVersions.Update(updateGameVersion);
            return await _databaseContext.SaveChangesAsync() > 0;
        }

        // Delete a video game
        public async Task<bool> DeleteOneAsync(VideoGameVersion gameVersion)
        {
            _videoGameVersions.Remove(gameVersion);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
