namespace DAL.Interfaces
{
    public interface IGetByUserIdRepository<T>
    {
        public Task<T?> GetByUserIdAsync(int userId);
    }
}
