using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Commands
{
    public class RegisterForEventTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.RegisterEmail(It.IsAny<EmailToEventEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutError()
        {
            var command = new RegisterForEventCommand();
            var handler = new RegisterForEventCommandHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsNull(result.Errors);
            Assert.IsTrue(result.Success);
        }
    }
}
