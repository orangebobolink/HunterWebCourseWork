using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.MessangerRepository
{
    internal class MessangerReposiotry : BaseRepository<Messanger>, IMessangerRepository
    {
        public MessangerReposiotry(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Messanger>> GetAllAsync()
            => await _dbContext.Messangers
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Messanger?> GetByIdAsync(int id)
            => await _dbContext.Messangers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
    }
}
