namespace DAL.Interfaces
{
    public interface IGetAllByPredictRepository<T>
    {
        public Task<IEnumerable<T>> GetAllByPredict(Func<T, bool> predicate);
    }
}
