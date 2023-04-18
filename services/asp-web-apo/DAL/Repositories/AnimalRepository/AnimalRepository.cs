using DAL.Data;
using DAL.Entities.AnimalEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.AnimalRepository
{
    internal class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Animal>> GetAll()
            => await _dbContext.Animals
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<Animal>> GetAllWithDetailsAsync()
            => await _dbContext.Animals
            .Include(a => a.AnimalDetail)
            .AsNoTracking()
            .ToListAsync();

        public async override Task<Animal?> GetById(int id)
            => await _dbContext.Animals
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Animal?> GetByIdWithDetailsAsync(int id)
            => await _dbContext.Animals
            .Include(a => a.AnimalDetail)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Animal?> GetByName(string name)
            => await _dbContext.Animals
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Name == name);
    }
}
