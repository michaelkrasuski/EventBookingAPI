using EventBooking.Application.UseCase.Events.Commands.Bases;
using EventBooking.Application.UseCase.Events.Validators;
using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.UpdateEvent
{
    public class UpdateEventValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventValidator()
        {
            RuleFor(x => (EventBaseCommand) x).SetValidator(new EventValidator());
        }
    }
}
