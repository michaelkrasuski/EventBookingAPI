using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Application.UseCase.Events.Commands.Bases
{
    public class EventBaseCommand
    {
        /// <summary>
        /// Event's name - single line with max 20 letters 
        /// </summary>
        [Required]
        public string? Name { get; set; }
        /// <summary>
        /// Event's Start Date
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Event's description - long multiline string
        /// </summary>
        [Required]
        public string? Description { get; set; }

        /// <summary>
        /// Number of seats - Event can be 100 max
        /// </summary>
        [Required]
        public int? NoOfSeats { get; set; }
        /// <summary>
        /// Country where Event takes place - max 20 letters
        /// </summary>
        [Required]
        public string? Country { get; set; }
    }
}
