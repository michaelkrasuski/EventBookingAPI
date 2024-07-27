using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent
{
    public class GetByEventCountryQuery : IRequest<BaseResponse<IEnumerable<EventBasicDto>>>
    {
        public string? Country { get; set; }
    }
}
