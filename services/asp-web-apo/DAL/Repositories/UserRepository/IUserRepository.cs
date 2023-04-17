using DAL.Entities.UserEntities;
using DAL.Interfaces;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> GetAllIncludeDetailAsync();
        public Task<User?> GetByIdIncludeDetailAsync(int id);
    }
}
