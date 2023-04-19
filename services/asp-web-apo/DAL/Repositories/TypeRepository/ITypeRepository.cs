using DAL.Entities.HuntingSeasonEntities;
using DAL.Interfaces;

namespace DAL.Repositories.TypeRepository
{
    public interface ITypeRepository : IRepository<TypeOfHunting>, IGetByNameRepository<TypeOfHunting>
    {
    }
}
