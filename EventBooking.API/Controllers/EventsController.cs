using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;
using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;
using EventBooking.Application.UseCase.Events.Commands.UpdateEvent;
using EventBooking.Application.UseCase.Events.Queries.GetAllEvents;
using EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent;
using EventBooking.Application.UseCase.Events.Queries.GetByIdEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [HttpPost("Create")]
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
        [HttpPut("Update")]
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
        [HttpDelete("Delete")]
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
        /// Fetches all Event Booking items
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await Mediator.Send(new GetAllEventsQuery(), ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Fetches Event Booking items by Country
        /// </summary>
        /// <param name="getByEventCountryQuery"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("GetByCountry")]
        public async Task<IActionResult> GetByCountry([FromQuery] GetByEventsCountryQuery getByEventCountryQuery, CancellationToken ct)
        {
            var result = await Mediator.Send(getByEventCountryQuery, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Fetches Event Booking item by name
        /// </summary>
        /// <param name="getByEventNameQuery"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] GetByEventNameQuery getByEventNameQuery, CancellationToken ct)
        {
            var result = await Mediator.Send(getByEventNameQuery, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Registers for an event by name using email address
        /// </summary>
        /// <param name="registerForEventCommand"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromQuery] RegisterForEventCommand registerForEventCommand, CancellationToken ct)
        {
            var result = await Mediator.Send(registerForEventCommand, ct);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
