using DAL.Data;
using DAL.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RoleRepository
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Role>> GetAllAsync()
             => await _dbContext.Roles
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Role?> GetByIdAsync(int id)
             => await _dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<Role?> GetByNameAsync(string name)
             => await _dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);
    }
}
