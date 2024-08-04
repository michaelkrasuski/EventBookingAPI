using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Domain.Entities
{
    [Index(nameof(Name))]
    [Index(nameof(Country))]
    public class EventEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public string? Description { get; set; }

        public int? NoOfSeats { get; set; }

        public string? Country { get; set; }

        public ICollection<EmailToEventEntity> EmailToEvents { get; set; } = [];
    }
}
