using DAL.Data;
using DAL.Entities.HuntingSeasonEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.MethodRepository
{
    internal class MethodRepository : BaseRepository<MethodOfHunting>, IMethodRepository
    {
        public MethodRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<MethodOfHunting>> GetAllAsync()
          => await _dbContext.Methods
              .AsNoTracking()
              .ToListAsync();

        public async override Task<MethodOfHunting?> GetByIdAsync(int id)
             => await _dbContext.Methods
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<MethodOfHunting?> GetByNameAsync(string name)
            => await _dbContext.Methods
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);
    }
}
