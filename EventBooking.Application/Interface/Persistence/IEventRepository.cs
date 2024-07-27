using EventBooking.Domain.Entities;

namespace EventBooking.Application.Interface.Persistence
{
    public interface IEventRepository : IGenericRepository<EventEntity>
    {
        Task<IEnumerable<EventEntity>> GetByCountry(string country, CancellationToken ct);

        Task<bool> RegisterEmail(EmailToEventEntity entity, CancellationToken ct);
    }
}
