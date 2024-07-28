using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent;
using EventBooking.Domain.Entities;
using Moq;

namespace EventBooking.Application.Tests.Events.Commands
{
    [TestClass]
    public class AuthenticateTests
    {
        private AuthenticateCommandHandler _commandHandler;

        private readonly Mock<IUserRepository> UserRepositoryMock;
        private readonly Mock<IUnitOfWork> UnitOfWorkMock;

        public AuthenticateTests()
        {
            UserRepositoryMock = new();
            UnitOfWorkMock = new();
        }

        [TestInitialize]
        public void Init()
        {
            UserRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<UserEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            UnitOfWorkMock.Setup(x => x.Users).Returns(UserRepositoryMock.Object);
        }

        [TestMethod]
        public async Task HandlesWithoutAnyError()
        {
            var command = new AuthenticateCommand { Secret = Guid.NewGuid().ToString() };
            _commandHandler = new AuthenticateCommandHandler(UnitOfWorkMock.Object);
            var result = await _commandHandler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNull(result.Errors);
        }
    }
}
