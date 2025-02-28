﻿namespace EventBooking.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        /* Commands */
        Task<bool> InsertAsync(T entity, CancellationToken ct);
        Task<bool> UpdateAsync(T entity, CancellationToken ct);
        Task<bool> DeleteAsync(string key, CancellationToken ct);
        /* Queries */
        Task<T?> GetAsync(string key, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
    }
}
