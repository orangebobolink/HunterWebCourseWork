namespace DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task AddAsync(T item);
        public Task Update(T item);
        public Task Remove(int id);
        public Task SaveChangesAsync();
    }
}
