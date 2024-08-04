using Microsoft.EntityFrameworkCore;

namespace EventBooking.Domain.Entities
{
    public class EmailToEventEntity
    {
        public string? Email { get; set; }
        public long? EventId { get; set; }

        public EventEntity? EventEntity { get; set; }
    }
}
