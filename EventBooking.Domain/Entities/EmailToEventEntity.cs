using Microsoft.EntityFrameworkCore;

namespace EventBooking.Domain.Entities
{
    [PrimaryKey(nameof(Email), nameof(EventId))]
    public class EmailToEventEntity
    {
        public string? Email { get; set; }
        public long? EventId { get; set; }

        public EventEntity? EventEntity { get; set; }
    }
}
