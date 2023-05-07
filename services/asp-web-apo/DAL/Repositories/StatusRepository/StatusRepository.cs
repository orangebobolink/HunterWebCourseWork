using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.StatusRepository
{
    internal class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public override Task<IEnumerable<Status>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Status?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Status?> GetByNameAsync(string name)
             => await _dbContext.Statuses
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == name);
    }
}
