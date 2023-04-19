using DAL.Data;
using DAL.Entities.HuntingSeasonEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.TypeRepository
{
    internal class TypeRepository : BaseRepository<TypeOfHunting>, ITypeRepository
    {
        public TypeRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<TypeOfHunting>> GetAllAsync()
         => await _dbContext.Types
             .AsNoTracking()
             .ToListAsync();

        public async override Task<TypeOfHunting?> GetByIdAsync(int id)
             => await _dbContext.Types
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<TypeOfHunting?> GetByNameAsync(string name)
            => await _dbContext.Types
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);
    }
}
