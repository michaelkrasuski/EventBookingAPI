using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;

namespace EventBooking.Application.Tests.Events.Validators
{
    [TestClass]
    public class RegisterForEventValidatorTests
    {
        [TestMethod]
        [DataRow(null, null, false)]
        [DataRow(null, "", false)]
        [DataRow("", null, false)]
        [DataRow("", "", false)]
        [DataRow("", "event", false)]
        [DataRow("email@test.com", "", false)]
        [DataRow("email@@test.com", "event", false)]
        [DataRow("email@test.com", "event", true)]
        public void ValidateRegisterForEvent(string? email, string? eventName, bool expected)
        {
            var validator = new RegisterForEventValidator();

            var command = new RegisterForEventCommand { Email = email, EventName = eventName };

            var result = validator.Validate(command);

            Assert.AreEqual(expected, result.IsValid);
        }
    }
}
