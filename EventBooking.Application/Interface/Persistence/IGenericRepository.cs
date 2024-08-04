namespace EventBooking.Application.Interface.Persistence
{
    public interface IGenericRepository<T, Y> where T : class
    {
        /* Commands */
        Task<bool> InsertAsync(T entity, CancellationToken ct);
        Task<bool> UpdateAsync(T entity, CancellationToken ct);
        Task<bool> DeleteAsync(Y key, CancellationToken ct);
        /* Queries */
        Task<T?> GetAsync(Y key, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
    }
}
