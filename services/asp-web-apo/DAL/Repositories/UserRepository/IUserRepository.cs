using DAL.Entities.UserEntities;
using DAL.Interfaces;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>, IGetByEmailRepository<User>
    {
        public Task<IEnumerable<User>> GetAllIncludeDetailAsync();
        public Task<User?> GetByIdIncludeDetailAsync(int id);
    }
}
