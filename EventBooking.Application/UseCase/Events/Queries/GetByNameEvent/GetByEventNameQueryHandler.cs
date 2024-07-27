using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetByIdEvent
{
    public class GetByEventNameQueryHandler : IRequestHandler<GetByEventNameQuery, BaseResponse<EventDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByEventNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<EventDto>> Handle(GetByEventNameQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<EventDto>();

            try
            {
                var eventEntity = await _unitOfWork.Events.GetAsync(request.Name!, cancellationToken);

                if (eventEntity is not null)
                {
                    response.Data = _mapper.Map<EventDto>(eventEntity);
                    response.Success = true;
                    response.Message = "Query succeed!";
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
