using AutoMapper;
using EventBooking.Application.UseCase.Events.Commands.RegisterForEvent;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.UseCase.Mappings
{
    public class EmailToEventMapper : Profile
    {
        public EmailToEventMapper()
        {
            CreateMap<EmailToEventEntity, RegisterForEventCommand>().ReverseMap();
        }
    }
}
