using DAL.Data;
using DAL.Entities.HuntingSeasonEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.GenderRepository
{
    internal class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Gender>> GetAllAsync()
          => await _dbContext.Genders
              .AsNoTracking()
              .ToListAsync();

        public async override Task<Gender?> GetByIdAsync(int id)
             => await _dbContext.Genders
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<Gender?> GetByNameAsync(string name)
            => await _dbContext.Genders
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);
    }
}
