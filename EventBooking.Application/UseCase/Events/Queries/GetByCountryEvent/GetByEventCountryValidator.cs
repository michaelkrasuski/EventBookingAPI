using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent
{
    public class GetByEventCountryValidator : AbstractValidator<GetByEventCountryQuery>
    {
        public GetByEventCountryValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .NotNull();
        }
    }
}
