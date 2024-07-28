using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, BaseResponse<IEnumerable<EventBasicDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<EventBasicDto>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<EventBasicDto>>();

            try
            {
                var events = await _unitOfWork.Events.GetAllAsync(cancellationToken);

                if (events is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<EventBasicDto>>(events);
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
