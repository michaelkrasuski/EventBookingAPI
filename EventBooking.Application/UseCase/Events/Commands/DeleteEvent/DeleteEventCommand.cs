using EventBooking.Application.UseCase.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Application.UseCase.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<BaseResponse<bool>>
    {
        [Required]
        public string? Name { get; set; }
    }
}
