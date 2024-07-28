using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Commands
{
    [TestClass]
    public class CreateEventTests : TestBase
    {     
        private CreateEventCommandHandler? _commandHandler;

        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<EventEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutAnyError()
        {
            var command = new CreateEventCommand();
            _commandHandler = new CreateEventCommandHandler(UnitOfWorkMock.Object, MapperMock.Object);
            var result = await _commandHandler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNull(result.Errors);
        }
    }
}
