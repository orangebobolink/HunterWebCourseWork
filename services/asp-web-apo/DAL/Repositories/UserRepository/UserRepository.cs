using DAL.Data;
using DAL.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.UserRepository
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<User>> GetAllAsync()
             => await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<User?>> GetAllIncludeDetailAsync()
             => await _dbContext.Users
                .Include(u => u.UserDetail)
                .Include(u => u.UserDetail.Messanger)
                .AsNoTracking()
                .ToListAsync();

        public async override Task<User?> GetByIdAsync(int id)
            => await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetByIdIncludeDetailAsync(int id)
            => await _dbContext.Users
                .Include(u => u.UserDetail)
                .Include(u => u.UserDetail.Messanger)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
    }
}
