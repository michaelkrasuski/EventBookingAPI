using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Application.UseCase.Events.Queries.GetByIdEvent
{
    public class GetByEventNameQuery : IRequest<BaseResponse<EventDto>>
    {
        [Required]
        public string? Name { get; set; }
    }
}
