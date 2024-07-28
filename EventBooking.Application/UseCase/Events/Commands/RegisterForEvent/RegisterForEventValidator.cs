using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.RegisterForEvent
{
    public class RegisterForEventValidator : AbstractValidator<RegisterForEventCommand>
    {
        public RegisterForEventValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.EventName)
                .NotEmpty();
        }
    }
}
