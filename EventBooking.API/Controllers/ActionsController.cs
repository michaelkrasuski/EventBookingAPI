using EventBooking.API.Attributes.EventBookingAPI.API.Attributes;
using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ActionsController : ControllerBase
    {
        private readonly IMediator Mediator;

        public ActionsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Registers for an event by name using email address
        /// </summary>
        /// <param name="registerForEventCommand"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterAsync([FromQuery] RegisterForEventCommand registerForEventCommand, CancellationToken ct)
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
