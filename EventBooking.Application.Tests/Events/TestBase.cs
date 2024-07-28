using AutoMapper;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Domain.Entities;
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
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            EventRepositoryMock = new Mock<IEventRepository>();
        }

        protected void InitBase(Mock<IEventRepository> eventRepoMock)
        {            
            UnitOfWorkMock.Setup(x => x.Events).Returns(eventRepoMock.Object);

            MapperMock = new Mock<IMapper>();
        }
    }
}
