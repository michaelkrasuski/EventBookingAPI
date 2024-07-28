namespace EventBooking.Domain.Events
{
    public class CreateEvent : BaseEvent
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Description { get; set; }
        public int? NoOfSeats { get; set; }
        public long? CountryId { get; set; }
    }
}
