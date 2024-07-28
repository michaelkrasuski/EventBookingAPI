using EventBooking.API.Controllers;
using EventBooking.API.Models;
using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace EventBooking.API.Tests.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Mock<IOptions<AppSettings>> _appSettingsMock;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Init()
        {
            _mediatorMock = new();
            _appSettingsMock = new();
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task Authenticate(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<AuthenticateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<AuthenticateResponseDto>(isOk));
            _appSettingsMock.Setup(x => x.Value).Returns(new AppSettings { Secret = "secret" });

            var controller = new UsersController(_appSettingsMock.Object, _mediatorMock.Object);

            var result = await controller.AuthenticateAsync();

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
