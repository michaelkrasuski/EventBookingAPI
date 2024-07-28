using AutoMapper;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using EventBooking.Domain.Entities;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.RegisterForEvent
{
    public class RegisterForEventCommandHandler : IRequestHandler<RegisterForEventCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterForEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(RegisterForEventCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var entity = _mapper.Map<EmailToEventEntity>(request);

                response.Data = await _unitOfWork.Events.RegisterEmail(entity, cancellationToken);

                if (response.Data)
                {
                    response.Success = true;
                    response.Message = $"Registered for an event: {request.EventName}!";
                }
        }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
