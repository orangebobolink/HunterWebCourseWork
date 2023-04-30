namespace BLL.Interfaces
{
    public interface IBaseService<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T> AddAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task<T> RemoveAsync(T item);
    }
}
