using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Entities
{
    public class EventEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public string? Description { get; set; }

        public int? NoOfSeats { get; set; }

        public string? Country { get; set; }

        public ICollection<EmailToEventEntity> EmailToEvents { get; set; } = [];
    }
}
