namespace DAL.Interfaces
{
    public interface IGetByEmailRepository<T>
    {
        public Task<T?> GetByEmailAsync(string email);
    }
}
