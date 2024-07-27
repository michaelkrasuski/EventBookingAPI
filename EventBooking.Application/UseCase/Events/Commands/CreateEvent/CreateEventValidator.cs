using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.CreateEvent
{
    public class CreateEventValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .Must(BeSingleLine).WithMessage("Field must be a single line");

            RuleFor(x => x.Country).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.NoOfSeats).NotEmpty().LessThanOrEqualTo(100);
            RuleFor(x => x.StartDate).NotEmpty();
        }

        private bool BeSingleLine(string value) => !value.Contains(Environment.NewLine);
    }
}
