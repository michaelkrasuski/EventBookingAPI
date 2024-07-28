using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;

namespace EventBooking.Application.Tests.Events.Validators
{
    [TestClass]
    public class AuthenticateValidatorTests
    {
        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("secret", true)]
        public void ValidateAuthenticate(string secret, bool expected)
        {
            var validator = new AuthenticateValidator();

            var result = validator.Validate(new AuthenticateCommand { Secret = secret });

            Assert.AreEqual(expected, result.IsValid);
        }
    }
}
