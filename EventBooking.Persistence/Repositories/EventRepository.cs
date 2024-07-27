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

        public async Task<bool> DeleteAsync(long id)
        {
            var eventEntity = await GetAsync(id);
            
            if (eventEntity == null)
            {
                //not found
                return false;
            }

            _dbContext.Events.Remove(eventEntity!);

            var deleted = await _dbContext.SaveChangesAsync();

            return deleted == 1;
        }

        public async Task<IEnumerable<EventEntity>> GetAllAsync()
        {
            return await _dbContext.Events.AsNoTracking().ToListAsync();
        }

        public async Task<EventEntity?> GetAsync(long id)
        {
            return await _dbContext.Events.FindAsync(id);
        }

        public async Task<IEnumerable<EventEntity>> GetByCountryId(long countryId)
        {
            return await _dbContext.Events.Where(x => x.CountryId == countryId).ToListAsync();
        }

        public async Task<bool> InsertAsync(EventEntity entity)
        {
            await _dbContext.AddAsync(entity);
            var added = await _dbContext.SaveChangesAsync();
            return added == 1;
        }

        public async Task<bool> UpdateAsync(EventEntity entity)
        {
            _dbContext.Events.Update(entity);
            var updated = await _dbContext.SaveChangesAsync();
            return updated == 1;
        }
    }
}
