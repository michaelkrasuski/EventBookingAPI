using EventBooking.Application.UseCase.Events.Commands.Bases;
using EventBooking.Application.UseCase.Events.Validators;

namespace EventBooking.Application.Tests.Events.Validators
{
    [TestClass]
    public class EventValidatorTests
    {
        private readonly EventValidator Validator = new ();

        private readonly DateTime Tomorrow = DateTime.Today.AddDays(1);

        [TestMethod]
        public void ValidatesWithErrorForEmptyCommand()
        {
            var command = new EventBaseCommand();

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidatesOk()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 20), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 100, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidateShowsNameMultilineError()
        {
            var command = new EventBaseCommand { Name = $"EventName {Environment.NewLine} multiline", Country = "Poland", Description = "Description \n multiline", NoOfSeats = 100, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateNameLengthError()
        {
            var command = new EventBaseCommand { Name = new string('x', 51), Country = "Poland", Description = "Description \n multiline", NoOfSeats = 100, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateCountryLengthError()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 21), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 100, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateNoOfSeatsMoreThan100Error()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 20), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 101, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateNoOfSeatsIsZeroError()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 20), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 0, StartDate = Tomorrow };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateEventThatTookPlaceYesterdayError()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 20), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 15, StartDate = DateTime.Today.AddMilliseconds(-1) };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidateEventThatTakesPlaceNow()
        {
            var command = new EventBaseCommand { Name = new string('x', 50), Country = new string('x', 20), Description = $"Description {Environment.NewLine} multiline", NoOfSeats = 15, StartDate = DateTime.Now };

            var result = Validator.Validate(command);

            Assert.IsFalse(result.IsValid);
        }
    }
}
