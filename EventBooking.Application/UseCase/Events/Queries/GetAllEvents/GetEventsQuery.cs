using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetEvents
{
    public class GetEventsQuery : IRequest<BaseResponse<IEnumerable<EventBasicDto>>>
    {
        public string? Country { get; set; }
    }
}
