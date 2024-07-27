using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Commands.DeleteEvent
{
    public class DeleteEventValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
