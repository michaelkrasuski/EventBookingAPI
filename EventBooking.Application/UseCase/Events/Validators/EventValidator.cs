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
            .MaximumLength(50);

            When(x => x.Name is not null, () =>
            {
                RuleFor(x => x.Name).Must(BeSingleLine!).WithMessage("Field must be a single line");
            });
                

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.NoOfSeats)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(100);

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .Must(BeInFuture).WithMessage("Cannot add event that is in the past or happens today!");
        }

        private bool BeSingleLine(string value) => !value.Contains(Environment.NewLine);

        private bool BeInFuture(DateTime value) => value > DateTime.Today.AddDays(1).AddSeconds(-1);
    }
}
