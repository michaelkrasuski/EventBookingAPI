using EventBooking.API.Attributes.EventBookingAPI.API.Attributes;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;
using EventBooking.Application.UseCase.Events.Commands.UpdateEvent;
using EventBooking.Application.UseCase.Events.Queries.GetByIdEvent;
using EventBooking.Application.UseCase.Events.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class EventsController : ControllerBase
    {
        private readonly IMediator Mediator;


        public EventsController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates new Event Booking item
        /// </summary>
        /// <param name="createEventCommand"></param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEventCommand createEventCommand, CancellationToken ct)
        {
            var result = await Mediator.Send(createEventCommand, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// This endpoint updates existing Event Booking item
        /// </summary>
        /// <param name="updateEventCommand"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEventCommand updateEventCommand, CancellationToken ct)
        {
            var result = await Mediator.Send(updateEventCommand, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Removes Event with all registered emails
        /// </summary>
        /// <param name="deleteEventCommand"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteEventCommand deleteEventCommand, CancellationToken ct)
        {
            var result = await Mediator.Send(deleteEventCommand, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Fetches Booking events
        /// </summary>
        /// <param name="country">country name parameter</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventsAsync(string? country, CancellationToken ct)
        {
            var result = await Mediator.Send(new GetEventsQuery { Country = country }, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventAsync(string? name, CancellationToken ct)
        {
            var result = await Mediator.Send(new GetByEventNameQuery { Name = name }, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }       
    }
}
