using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.FeedbackRepository
{
    internal class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Feedback>> GetAllAsync()
             => await _dbContext.Feedbacks
            .Include(f => f.User)
            .Include(f => f.User!.UserDetail)
            .AsNoTracking()
            .ToListAsync();

        public override async Task<Feedback?> GetByIdAsync(int id)
              => await _dbContext.Feedbacks
            .Include(f => f.User)
            .Include(f => f.User!.UserDetail)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
