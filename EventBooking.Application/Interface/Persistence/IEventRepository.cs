using EventBooking.Domain.Entities;

namespace EventBooking.Application.Interface.Persistence
{
    public interface IEventRepository : IGenericRepository<EventEntity, long>
    {
        Task<IEnumerable<EventEntity>> GetByCountry(string country, CancellationToken ct);

        Task<EventEntity?> GetByName(string name, CancellationToken ct);

        Task<bool> RegisterEmail(EmailToEventEntity entity, CancellationToken ct);
    }
}
