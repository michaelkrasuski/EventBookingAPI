using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;

namespace EventBooking.Application.Tests.Events.Validators
{
    [TestClass]
    public class DeleteEventValidatorTests
    {
        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("Testing", true)]
        public void ValidateShouldReturnError(string? name, bool expectedResult)
        {
            var deleteValidator = new DeleteEventValidator();

            var deleteCommand = new DeleteEventCommand { Name = name };
            var result = deleteValidator.Validate(deleteCommand);

            Assert.AreEqual(expectedResult, result.IsValid);
        }
    }
}
