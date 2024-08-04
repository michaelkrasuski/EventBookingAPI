using EventBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Persistence
{
    public class EventBookingDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public DbSet<EmailToEventEntity> EmailToEvents { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EventEntity>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<EventEntity>()
                .HasIndex(x => x.Country);

            modelBuilder.Entity<EmailToEventEntity>()
                .HasKey(x => new { x.EventId, x.Email });

            modelBuilder.Entity<UserEntity>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
