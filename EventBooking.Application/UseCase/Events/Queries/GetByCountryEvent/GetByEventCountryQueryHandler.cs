using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using MediatR;

namespace EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent
{
    public class GetByEventCountryQueryHandler : IRequestHandler<GetByEventCountryQuery, BaseResponse<IEnumerable<EventBasicDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByEventCountryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<EventBasicDto>>> Handle(GetByEventCountryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<EventBasicDto>>();

            try
            {
                var eventEntity = await _unitOfWork.Events.GetByCountry(request.Country!, cancellationToken);

                if (eventEntity is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<EventBasicDto>>(eventEntity);
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
