using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<BaseResponse<IEnumerable<EventBasicDto>>>
    {
    }
}
