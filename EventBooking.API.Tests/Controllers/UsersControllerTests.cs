using EventBooking.API.Controllers;
using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EventBooking.API.Tests.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {
        [TestInitialize]
        public void Init()
        {
            _mediatorMock = new();
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task Authenticate(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<AuthenticateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<AuthenticateResponseDto>(isOk));

            var controller = new UsersController(_mediatorMock.Object);

            var result = await controller.AuthenticateAsync();

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
