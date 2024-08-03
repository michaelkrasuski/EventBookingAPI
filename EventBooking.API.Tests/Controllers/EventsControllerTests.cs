using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;
using EventBooking.Application.UseCase.Events.Commands.UpdateEvent;
using EventBooking.Application.UseCase.Events.Queries.GetByIdEvent;
using EventBooking.Application.UseCase.Events.Queries.GetEvents;
using EventBookingAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EventBooking.API.Tests.Controllers
{
    [TestClass]
    public class EventsControllerTests : ControllerTestsBase
    {
        [TestInitialize]
        public void Init()
        {            
            _mediatorMock = new();           
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task CreateEndpoint(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<bool>(isOk));

            var controller = new EventsController(_mediatorMock.Object);

            var result = await controller.CreateAsync(new CreateEventCommand(), CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task UpdateEndpoint(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<bool>(isOk));

            var controller = new EventsController(_mediatorMock.Object);

            var result = await controller.UpdateAsync(new UpdateEventCommand(), CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<UpdateEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task DeleteEndpoint(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<bool>(isOk));

            var controller = new EventsController(_mediatorMock.Object);

            var result = await controller.DeleteAsync(new DeleteEventCommand(), CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<DeleteEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), "country", true)]
        [DataRow(typeof(OkObjectResult), null, true)]
        [DataRow(typeof(OkObjectResult), "", true)]
        [DataRow(typeof(BadRequestObjectResult), "country", false)]
        [DataRow(typeof(BadRequestObjectResult), null, false)]
        [DataRow(typeof(BadRequestObjectResult), "", false)]
        public async Task GetEventsAsyncEndpoint(Type actionResult, string? country, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetEventsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<IEnumerable<EventBasicDto>>(isOk));

            var controller = new EventsController(_mediatorMock.Object);

            var result = await controller.GetEventsAsync(country, CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);

            _mediatorMock.Verify(x => x.Send(It.IsAny<GetEventsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        [DataRow(typeof(OkObjectResult), true)]
        [DataRow(typeof(BadRequestObjectResult), false)]
        public async Task GetAllByNameEndpoint(Type actionResult, bool isOk)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetByEventNameQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetResponse<EventDto>(isOk));

            var controller = new EventsController(_mediatorMock.Object);

            var result = await controller.GetEventAsync("name", CancellationToken.None);

            Assert.IsInstanceOfType(result, actionResult);
            _mediatorMock.Verify(x => x.Send(It.IsAny<GetByEventNameQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
