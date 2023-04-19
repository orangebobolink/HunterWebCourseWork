using DAL.Entities.HuntingSeasonEntities;
using DAL.Interfaces;

namespace DAL.Repositories.MethodRepository
{
    public interface IMethodRepository : IRepository<MethodOfHunting>, IGetByNameRepository<MethodOfHunting>
    {
    }
}
