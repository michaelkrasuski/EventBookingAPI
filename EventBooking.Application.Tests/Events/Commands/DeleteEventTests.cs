using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;
using Moq;

namespace EventBooking.Application.Tests.Events.Commands
{
    [TestClass]
    public class DeleteEventTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutErrors()
        {
            var command = new DeleteEventCommand();
            var handler = new DeleteEventCommandHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNull(result.Errors);
        }
    }
}
