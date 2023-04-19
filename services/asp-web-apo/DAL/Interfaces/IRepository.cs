namespace DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public void Add(T item);
        public void Update(T item);
        public void Remove(T item);
        public Task SaveChangesAsync();
    }
}
