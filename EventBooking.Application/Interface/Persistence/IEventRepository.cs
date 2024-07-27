using EventBooking.Domain.Entities;

namespace EventBooking.Application.Interface.Persistence
{
    public interface IEventRepository : IGenericRepository<EventEntity>
    {
        Task<IEnumerable<EventEntity>> GetByCountryId(long countryId);
    }
}
