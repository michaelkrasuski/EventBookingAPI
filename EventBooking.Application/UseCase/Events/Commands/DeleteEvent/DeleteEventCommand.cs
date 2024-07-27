using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
