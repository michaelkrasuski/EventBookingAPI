namespace EventBooking.Application.UseCase.Events.Commands.Bases
{
    public class EventBaseCommand
    {
        /// <summary>
        /// Event's name - single line with max 20 letters 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Event's Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Event's description - long multiline string
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Number of seats - Event can be 100 max
        /// </summary>
        public int? NoOfSeats { get; set; }
        /// <summary>
        /// Country where Event takes place - max 20 letters
        /// </summary>
        public string? Country { get; set; }
    }
}
