using EventBooking.Application.Interface.Persistence;

namespace EventBooking.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository Events { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(IEventRepository events, IUserRepository users)
        {
            Events = events ?? throw new ArgumentNullException(nameof(events));
            Users = users;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
