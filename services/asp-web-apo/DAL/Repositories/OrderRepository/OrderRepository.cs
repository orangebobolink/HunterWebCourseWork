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

        public async override Task<IEnumerable<Order>> GetAll()
            => await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Messanger)
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Order?> GetById(int id)
            => await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Messanger)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
    }
}
