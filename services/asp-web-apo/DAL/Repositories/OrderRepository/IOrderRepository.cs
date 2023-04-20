using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>, IGetAllByPredictRepository<Order>
    {
    }
}
