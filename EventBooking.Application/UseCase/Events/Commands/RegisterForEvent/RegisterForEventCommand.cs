using EventBooking.Application.UseCase.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Application.UseCase.Events.Commands.RegisterForEvent
{
    public class RegisterForEventCommand : IRequest<BaseResponse<bool>>
    {
        [Required]
        public string? EventName { get; set; }
        [Required]

        public string? Email { get; set; }
    }
}
