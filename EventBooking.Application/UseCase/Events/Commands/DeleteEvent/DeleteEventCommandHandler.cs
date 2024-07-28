using AutoMapper;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await _unitOfWork.Events.DeleteAsync(request.Name!, cancellationToken);

                if (response.Data)
                {
                    response.Success = true;
                    response.Message = "Delete succeed!";
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
