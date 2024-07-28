using EventBooking.API.Models;
using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EventBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UsersController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly AppSettings AppSettings;
        public UsersController(IOptions<AppSettings> appSettings, IMediator mediator)
        {
            AppSettings = appSettings.Value;
            Mediator = mediator;
        }

        [HttpPost("Authenticate")]
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
