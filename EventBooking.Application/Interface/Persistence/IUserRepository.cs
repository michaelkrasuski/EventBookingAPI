using EventBooking.Domain.Entities;

namespace EventBooking.Application.Interface.Persistence
{
    public interface IUserRepository : IGenericRepository<UserEntity, Guid>
    {
    }
}
