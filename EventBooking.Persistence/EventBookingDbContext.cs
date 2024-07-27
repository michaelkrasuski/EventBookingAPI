using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Persistence
{
    public class EventBookingDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : base(options) { }
    }
}
