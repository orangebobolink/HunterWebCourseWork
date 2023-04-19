namespace DAL.Interfaces
{
    public interface IGetByNameRepository<T>
    {
        public Task<T?> GetByNameAsync(string name);
    }
}
