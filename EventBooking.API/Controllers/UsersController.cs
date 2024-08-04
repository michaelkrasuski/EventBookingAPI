using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UsersController : ControllerBase
    {
        private readonly IMediator Mediator;
        public UsersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Allows to acquire Bearer Token
        /// </summary>
        /// <returns>Bearer Token</returns>
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync()
        {
            var result = await Mediator.Send(new AuthenticateCommand());
            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest("Something  went wrong - please try again later");
        }
    }
}
