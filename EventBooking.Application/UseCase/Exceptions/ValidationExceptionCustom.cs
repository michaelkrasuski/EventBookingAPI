using EventBooking.Application.UseCase.Bases;

namespace EventBooking.Application.UseCase.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public IEnumerable<BaseError> Errors { get; }

        public ValidationExceptionCustom()
            : base("One or more validation failures have occured.")
        {
            Errors = [];
        }

        public ValidationExceptionCustom(IEnumerable<BaseError> errors)
            : this()
        {
            Errors = errors;
        }
    }
}
