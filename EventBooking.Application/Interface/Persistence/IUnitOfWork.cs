namespace EventBooking.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
    }
}
