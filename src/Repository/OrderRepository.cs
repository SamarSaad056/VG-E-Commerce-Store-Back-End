namespace FusionTech.src.Repository
{
    public class OrderRepository
    {
        protected readonly DbSet<Order> _order;
        protected readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _order = _databaseContext.Set<Order>();
        }

        public async Task<Order> CreateOneAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();

            // Load related OrderedGames
            await _databaseContext.Entry(newOrder).Collection(o => o.OrderedGames).LoadAsync();

            foreach (var details in newOrder.OrderedGames)
            {
                await _databaseContext
                    .Entry(details)
                    .Reference(od => od.VideoGameVersion)
                    .LoadAsync();
            }

            return newOrder;
        }

        public async Task<List<Order>> GetOrderByIdAsync(int CustomerId)
        {
            return await _order
                .Include(ord => ord.OrderedGames)
                .ThenInclude(ord => ord.VideoGameVersion)
                .Where(ord => ord.CustomerId == CustomerId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _order.Include(o => o.OrderedGames).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _order.CountAsync();
        }
    }
}
