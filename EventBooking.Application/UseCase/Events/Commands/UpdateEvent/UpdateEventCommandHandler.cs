using AutoMapper;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using EventBooking.Domain.Entities;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var eventEntity = _mapper.Map<EventEntity>(request);

                response.Data = await _unitOfWork.Events.UpdateAsync(eventEntity, cancellationToken);

                if (response.Data)
                {
                    response.Success = true;
                    response.Message = "Update succed!";
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
