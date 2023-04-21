namespace BLL.Interfaces
{
    public interface IGetByNameService<T> where T : class
    {
        public Task<T> GetByNameAsync(string name);
    }
}
