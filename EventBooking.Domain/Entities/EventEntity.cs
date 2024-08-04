
namespace EventBooking.Domain.Entities
{
    public class EventEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public string? Description { get; set; }

        public int? NoOfSeats { get; set; }

        public string? Country { get; set; }

        public ICollection<EmailToEventEntity> EmailToEvents { get; set; } = [];
    }
}
