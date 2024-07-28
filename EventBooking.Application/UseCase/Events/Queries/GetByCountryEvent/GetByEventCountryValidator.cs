using FluentValidation;

namespace EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent
{
    public class GetByEventCountryValidator : AbstractValidator<GetByEventsCountryQuery>
    {
        public GetByEventCountryValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .NotNull();
        }
    }
}
