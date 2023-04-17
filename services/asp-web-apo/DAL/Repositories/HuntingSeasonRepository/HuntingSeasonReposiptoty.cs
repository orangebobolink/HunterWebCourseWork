﻿using DAL.Data;
using DAL.Entities.HuntingSeasonEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.HuntingSeasonRepository
{
    internal class HuntingSeasonReposiptoty : BaseRepository<HuntingSeason>, IHuntingSeasonRepository
    {
        public HuntingSeasonReposiptoty(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<HuntingSeason>> GetAll()
            => await _dbContext.HuntingSeasons
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<HuntingSeason>> GetAllWithDetailsAsync()
            => await _dbContext.HuntingSeasons
            .Include(h => h.HuntingSeasonDetail)
            .AsNoTracking()
            .ToListAsync();

        public async override Task<HuntingSeason?> GetById(int id)
            => await _dbContext.HuntingSeasons
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id);

        public async Task<HuntingSeason?> GetByIdWithDetailsAsync(int id)
            => await _dbContext.HuntingSeasons
            .AsNoTracking()
            .Include(h => h.HuntingSeasonDetail)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
}
