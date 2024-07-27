using EventBooking.Application.Interface.Persistence;

namespace EventBooking.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository Events { get; }

        public UnitOfWork(IEventRepository events)
        {
            Events = events ?? throw new ArgumentNullException(nameof(events));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
