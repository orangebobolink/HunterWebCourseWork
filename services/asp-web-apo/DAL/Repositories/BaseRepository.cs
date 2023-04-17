using DAL.Data;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _dbContext;

        protected BaseRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<T?> GetById(int id);

        public void Add(T item)
            => _dbContext.Add(item);

        public void Remove(T item)
            => _dbContext.Remove(item);

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

        public void Update(T item)
            => _dbContext.Update(item);
    }
}
