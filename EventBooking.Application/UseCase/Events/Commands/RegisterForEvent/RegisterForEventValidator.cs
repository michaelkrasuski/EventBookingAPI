using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.RegisterForEvent
{
    public class RegisterForEventValidator : AbstractValidator<RegisterForEventCommand>
    {
        public RegisterForEventValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.EventName)
                .NotEmpty()
                .NotNull();
        }
    }
}
