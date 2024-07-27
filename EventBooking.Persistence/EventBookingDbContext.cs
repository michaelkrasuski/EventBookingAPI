using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Persistence
{
    public class EventBookingDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public DbSet<EmailToEventEntity> EmailToEvents { get; set; }

        public EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : base(options) { }
    }
}
