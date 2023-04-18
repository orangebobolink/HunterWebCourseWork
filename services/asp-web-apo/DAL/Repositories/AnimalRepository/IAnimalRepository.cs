using DAL.Entities.AnimalEntities;
using DAL.Interfaces;

namespace DAL.Repositories.AnimalRepository
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        public Task<Animal?> GetByName(string name);
        public Task<IEnumerable<Animal>> GetAllWithDetailsAsync();
        public Task<Animal?> GetByIdWithDetailsAsync(int id);
    }
}
