using EventBooking.Application.UseCase.Events.Commands.UpdateEvent;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Commands
{
    [TestClass]
    public class UpdateEventTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<EventEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutErrors()
        {
            var command = new UpdateEventCommand();
            var handler = new UpdateEventCommandHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);
            
            Assert.IsNotNull(result);
            Assert.IsNull(result.Errors);
            Assert.IsTrue(result.Success);
        }
    }
}
