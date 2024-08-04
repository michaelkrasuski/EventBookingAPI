using EventBooking.Application.UseCase.Events.Queries.GetEvents;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Queries
{
    [TestClass]
    public class GetEventsQueryTests : TestBase
    {
        private readonly List<EventEntity> Events = [new (), new ()];

        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Events);

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("country")]
        public async Task HandlesWithoutError(string country)
        {
            var query = new GetEventsQuery { Country = country };
            var handler = new GetEventsQueryHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsNull(result.Errors);
            Assert.IsTrue(result.Success);
        }
    }
}
