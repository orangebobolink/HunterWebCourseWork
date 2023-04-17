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

        public async override Task<IEnumerable<Token>> GetAll()
            => await _dbContext.Tokens
                .Include(t => t.User)
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Token?> GetById(int id)
             => await _dbContext.Tokens
                .Include(t => t.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
    }
}
