using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.RegisterForEvent
{
    public class RegisterForEventCommand : IRequest<BaseResponse<bool>>
    {
        public string? EventName { get; set; }

        public string? Email { get; set; }
    }
}
