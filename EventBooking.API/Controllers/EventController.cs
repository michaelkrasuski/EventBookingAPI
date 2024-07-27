using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator Mediator;


        public EventController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("Create")]
        [HttpPost]
        [SwaggerOperation("This endpoint creates new Event Booking item")]
        public async Task<IActionResult> Create(CancellationToken ct)
        {
            var result = await Mediator.Send(ct);

            return Ok(result);
        }
    }
}
