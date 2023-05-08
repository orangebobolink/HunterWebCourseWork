using DAL.Entities.HuntingSeasonEntities;
using DAL.Interfaces;

namespace DAL.Repositories.HuntingSeasonRepository
{
    public interface IHuntingSeasonRepository : IRepository<HuntingSeason>
    {
        public Task<IEnumerable<HuntingSeason>> GetAllWithDetailsAsync();
        public Task<HuntingSeason?> GetByIdWithDetailsAsync(int id);
        public Task<IEnumerable<HuntingSeason>> GetAllByAnimalIdAsync(int animalId);
    }
}
