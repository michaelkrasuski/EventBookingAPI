using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EventController : ControllerBase
    {
        private readonly IMediator Mediator;


        public EventController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates new Booking Event within In-Memory Database
        /// </summary>
        /// <param name="createEventCommand">Event command</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [SwaggerOperation("This endpoint creates new Event Booking item")]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand createEventCommand, CancellationToken ct)
        {
            var result = await Mediator.Send(createEventCommand, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
