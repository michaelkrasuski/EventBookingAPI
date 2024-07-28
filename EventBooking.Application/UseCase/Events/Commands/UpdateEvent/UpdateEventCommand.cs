using EventBooking.Application.UseCase.Bases;
using EventBooking.Application.UseCase.Events.Commands.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : EventBaseCommand, IRequest<BaseResponse<bool>>
    {
        public long Id { get; set; }
    }
}
