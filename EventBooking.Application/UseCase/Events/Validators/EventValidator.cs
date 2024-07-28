using EventBooking.Application.UseCase.Events.Commands.Bases;
using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Validators
{
    public class EventValidator : AbstractValidator<EventBaseCommand>
    {
        public EventValidator() 
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .Must(BeSingleLine).WithMessage("Field must be a single line");

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.NoOfSeats)
                .NotEmpty()
                .LessThanOrEqualTo(100);

            RuleFor(x => x.StartDate)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Cannot add event that is in the past!");
        }

        private bool BeSingleLine(string value) => !value.Contains(Environment.NewLine);
    }
}
