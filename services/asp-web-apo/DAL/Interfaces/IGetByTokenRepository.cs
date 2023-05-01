namespace DAL.Interfaces
{
    public interface IGetByTokenRepository<T>
    {
        public Task<T?> GetByTokenAsync(string token);
    }
}
