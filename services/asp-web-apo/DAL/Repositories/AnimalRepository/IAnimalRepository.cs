using DAL.Entities.AnimalEntities;
using DAL.Interfaces;

namespace DAL.Repositories.AnimalRepository
{
    public interface IAnimalRepository : IRepository<Animal>, IGetByNameRepository<Animal>
    {
        public Task<IEnumerable<Animal>> GetAllWithDetailsAsync();
        public Task<Animal?> GetByIdWithDetailsAsync(int id);
        public Task<Animal?> GetByEnglishNameAsync(string name);
    }
}
