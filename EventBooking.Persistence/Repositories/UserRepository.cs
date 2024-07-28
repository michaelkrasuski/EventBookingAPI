using EventBooking.Application.Interface.Persistence;
using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventBookingDbContext _dbContext;

        public UserRepository(EventBookingDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> DeleteAsync(string key, CancellationToken ct)
        {
            var userEntity = await _dbContext.Users.FindAsync(key, ct);

            if (userEntity is null)
            {
                return false;
            }

            _dbContext.Users.Remove(userEntity);

            var deleted = await _dbContext.SaveChangesAsync(ct);

            return deleted == 1;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync(ct);
        }

        public async Task<UserEntity?> GetAsync(string key, CancellationToken ct)
        {
            return await _dbContext.Users.FindAsync(key, ct);
        }

        public async Task<bool> InsertAsync(UserEntity entity, CancellationToken ct)
        {
            await _dbContext.AddAsync(entity, ct);

            var added = await _dbContext.SaveChangesAsync(ct);

            return added == 1;
        }

        public async Task<bool> UpdateAsync(UserEntity entity, CancellationToken ct)
        {
            _dbContext.Users.Update(entity);
            var updated = await _dbContext.SaveChangesAsync(ct);
            return updated == 1;
        }
    }
}
