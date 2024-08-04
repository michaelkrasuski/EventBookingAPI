using EventBooking.Application.Interface.Persistence;
using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventBookingDbContext _dbContext;

        public EventRepository(EventBookingDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> DeleteAsync(long key, CancellationToken ct)
        {
            var eventEntity = await _dbContext.Events
                .Include(x => x.EmailToEvents)
                .SingleOrDefaultAsync(x => x.Id == key, ct);
            
            if (eventEntity == null)
            {
                //not found
                return false;
            }

            var toBeDeleted = eventEntity.EmailToEvents.Count() + 1;

            _dbContext.Events.Remove(eventEntity!);

            var deleted = await _dbContext.SaveChangesAsync(ct);

            return deleted == toBeDeleted;
        }

        public async Task<IEnumerable<EventEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _dbContext.Events.AsNoTracking().ToListAsync(ct);
        }

        public async Task<EventEntity?> GetAsync(long key, CancellationToken ct)
        {
            return await _dbContext.Events.FindAsync(key, ct);
        }

        public async Task<IEnumerable<EventEntity>> GetByCountry(string country, CancellationToken ct)
        {
            return await _dbContext.Events.Where(x => x.Country!.Equals(country.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToListAsync(ct);
        }

        public async Task<EventEntity?> GetByName(string name, CancellationToken ct)
        {
            return await _dbContext.Events.SingleOrDefaultAsync(x => x.Name!.Equals(name.Trim(), StringComparison.CurrentCultureIgnoreCase), ct);
        }

        public async Task<bool> InsertAsync(EventEntity entity, CancellationToken ct)
        {
            await _dbContext.AddAsync(entity, ct);
            var added = await _dbContext.SaveChangesAsync(ct);
            return added == 1;
        }

        public async Task<bool> RegisterEmail(EmailToEventEntity entity, CancellationToken ct)
        {
            var eventEntity = await GetAsync(entity.EventId.GetValueOrDefault(), ct);

            if (eventEntity is null)
            {
                return false;
            }

            eventEntity!.EmailToEvents.Add(entity);

            var added = await _dbContext.SaveChangesAsync(ct);

            return added == 1;
        }

        public async Task<bool> UpdateAsync(EventEntity entity, CancellationToken ct)
        {
            _dbContext.Events.Update(entity);
            var updated = await _dbContext.SaveChangesAsync(ct);
            return updated == 1;
        }
    }
}
