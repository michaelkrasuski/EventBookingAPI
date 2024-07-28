using EventBooking.Application.UseCase.Events.Commands.Bases;
using EventBooking.Application.UseCase.Events.Validators;
using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.CreateEvent
{
    public class CreateEventValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventValidator()
        {
            RuleFor(x => (EventBaseCommand)x).SetValidator(new EventValidator());
        }
    }
}
