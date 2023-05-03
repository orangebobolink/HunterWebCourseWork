using DAL.Data;
using DAL.Entities;
using DAL.Migrations;
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
                .AsNoTracking()
                .ToListAsync();

        public async override Task<Token?> GetByIdAsync(int id)
             => await _dbContext.Tokens
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<Token?> GetByTokenAsync(string token)
            => await _dbContext.Tokens
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.RefreshToken == token);

        public async Task<Token?> GetByUserIdAsync(int userId)
            => await _dbContext.Tokens
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.UserId == userId);
    }
}
