using AutoMapper;
using EventBooking.Application.Interface.Persistence;
using Moq;

namespace EventBooking.Application.Tests.Events
{
    public class TestBase
    {
        protected Mock<IUnitOfWork> UnitOfWorkMock;
        protected Mock<IMapper> MapperMock;
        protected Mock<IEventRepository> EventRepositoryMock;

        public TestBase()
        {
            UnitOfWorkMock = new ();
            MapperMock = new ();
            EventRepositoryMock = new ();
        }

        protected void InitBase(Mock<IEventRepository> eventRepoMock)
        {            
            UnitOfWorkMock.Setup(x => x.Events).Returns(eventRepoMock.Object);

            MapperMock = new Mock<IMapper>();
        }
    }
}
