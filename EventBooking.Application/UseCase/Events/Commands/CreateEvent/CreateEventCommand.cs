using EventBooking.Application.UseCase.Bases;
using EventBooking.Application.UseCase.Events.Commands.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.CreateEvent
{
    public class CreateEventCommand : EventBaseCommand, IRequest<BaseResponse<bool>>
    {        
    }
}
