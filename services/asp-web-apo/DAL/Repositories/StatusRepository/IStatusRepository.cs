using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.StatusRepository
{
    public interface IStatusRepository : IRepository<Status>, IGetByNameRepository<Status>
    {
    }
}
