using DAL.Entities.UserEntities;
using DAL.Interfaces;

namespace DAL.Repositories.RoleRepository
{
    public interface IRoleRepository : IRepository<Role>, IGetByNameRepository<Role>
    {

    }
}
