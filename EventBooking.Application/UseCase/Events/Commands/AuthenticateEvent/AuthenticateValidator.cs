using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.Secret).NotEmpty();
        }
    }
}
