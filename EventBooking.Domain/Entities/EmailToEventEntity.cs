using Microsoft.EntityFrameworkCore;

namespace EventBooking.Domain.Entities
{
    [PrimaryKey(nameof(Email), nameof(EventName))]
    public class EmailToEventEntity
    {
        public string? Email { get; set; }
        public string? EventName { get; set; }

        public EventEntity? EventEntity { get; set; }
    }
}
