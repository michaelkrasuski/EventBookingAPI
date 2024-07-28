using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent
{
    public class GetByEventsCountryQuery : IRequest<BaseResponse<IEnumerable<EventBasicDto>>>
    {
        [Required]
        public string? Country { get; set; }
    }
}
