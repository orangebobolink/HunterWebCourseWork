using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.MessangerRepository
{
    public interface IMessangerRepository : IRepository<Messanger>, IGetByNameRepository<Messanger>
    {

    }
}
