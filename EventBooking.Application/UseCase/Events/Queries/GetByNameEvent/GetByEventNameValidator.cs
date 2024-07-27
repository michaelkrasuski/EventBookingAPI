using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Queries.GetByIdEvent
{
    public class GetByEventNameValidator : AbstractValidator<GetByEventNameQuery>
    {
        public GetByEventNameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
