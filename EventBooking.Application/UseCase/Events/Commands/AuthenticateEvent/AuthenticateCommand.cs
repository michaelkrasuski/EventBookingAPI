using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent
{
    public class AuthenticateCommand : IRequest<BaseResponse<AuthenticateResponseDto>>
    {
    }
}
