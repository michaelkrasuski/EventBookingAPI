using EventBooking.API.Controllers;
using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EventBooking.API.Tests.Controllers
{
    [TestClass]
    public class ActionsControllerTests : ControllerTestsBase
    {
        [TestInitialize]
        public void Init()
        {
            _mediatorMock = new();
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task RegisterTests(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<RegisterForEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<bool>(isOk));

            var controller = new ActionsController(_mediatorMock.Object);

            var result = await controller.RegisterAsync(new RegisterForEventCommand(), CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<RegisterForEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
