namespace BLL.Interfaces
{
    public interface IRepositoryService<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Remove(T item);
    }
}
