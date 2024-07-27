using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetByIdEvent
{
    public class GetByEventNameQuery : IRequest<BaseResponse<EventDto>>
    {
        public string? Name { get; set; }
    }
}
