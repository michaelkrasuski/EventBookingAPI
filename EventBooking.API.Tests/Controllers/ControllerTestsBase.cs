using EventBooking.Application.UseCase.Bases;
using MediatR;
using Moq;

namespace EventBooking.API.Tests.Controllers
{
    public class ControllerTestsBase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Mock<IMediator> _mediatorMock;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected BaseResponse<T> GetResponse<T>(bool isOk) => new() { Success = isOk };
    }
}
