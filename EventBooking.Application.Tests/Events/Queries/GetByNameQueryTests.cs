using EventBooking.Application.UseCase.Events.Queries.GetByIdEvent;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Queries
{
    [TestClass]
    public class GetByNameQueryTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            EventRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(new EventEntity());

            InitBase(EventRepositoryMock);
        }

        [TestMethod]
        public async Task HandlesWithoutError()
        {
            var query = new GetByEventNameQuery();
            var handler = new GetByEventNameQueryHandler(UnitOfWorkMock.Object, MapperMock.Object);

            var result = await handler.Handle(query, CancellationToken.None); 

            Assert.IsNotNull(result);
            Assert.IsNull(result.Errors);
            Assert.IsTrue(result.Success);
        }
    }
}
