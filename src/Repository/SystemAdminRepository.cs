namespace FusionTech.src.Repository
{
    public class SystemAdminRepository
    {
        protected DbSet<SystemAdmin> _systemAdmin;
        protected DatabaseContext _databaseContext;

        public SystemAdminRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _systemAdmin = _databaseContext.Set<SystemAdmin>();
        }

        public async Task<SystemAdmin> CreateOneAsync(SystemAdmin systemAdmin)
        {
            await _systemAdmin.AddAsync(systemAdmin);
            await _databaseContext.SaveChangesAsync();
            return systemAdmin;
        }

        public async Task<SystemAdmin?> GetByIdAsync(int id)
        {
            return await _systemAdmin.FindAsync(id);
        }

        public async Task<List<SystemAdmin>> GetAllAsync()
        {
            return await _systemAdmin.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _systemAdmin.CountAsync();
        }
    }
}
