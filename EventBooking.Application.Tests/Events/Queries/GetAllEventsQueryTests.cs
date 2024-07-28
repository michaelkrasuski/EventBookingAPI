using EventBooking.Application.UseCase.Events.Queries.GetAllEvents;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Queries
{
    [TestClass]
    public class GetAllEventsQueryTests : TestBase
    {
        private readonly List<EventEntity> Events = [new (), new ()];

        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Events);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutError()
        {
            var query = new GetAllEventsQuery();
            var handler = new GetAllEventsQueryHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsNull(result.Errors);
            Assert.IsTrue(result.Success);
        }
    }
}
