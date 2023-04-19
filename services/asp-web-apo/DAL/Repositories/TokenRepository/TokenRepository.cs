using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.TokenRepository
{
    internal class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        public TokenRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Token>> GetAllAsync()
            => await _dbContext.Tokens
                .Include(t => t.User)
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Token?> GetByIdAsync(int id)
             => await _dbContext.Tokens
                .Include(t => t.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
    }
}
