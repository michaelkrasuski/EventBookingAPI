namespace EventBooking.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        /* Commands */
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
        /* Queries */
        Task<T?> GetAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
