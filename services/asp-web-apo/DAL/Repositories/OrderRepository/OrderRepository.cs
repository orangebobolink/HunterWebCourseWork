using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.OrderRepository
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllByPredict(Func<Order, bool> predicate)
            => _dbContext.Orders
                .Include(o => o.User)
                .AsNoTracking()
                .Where(predicate)
                .ToList();

        public async override Task<IEnumerable<Order>> GetAllAsync()
            => await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Status)
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Order?> GetByIdAsync(int id)
            => await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Status)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
    }
}
