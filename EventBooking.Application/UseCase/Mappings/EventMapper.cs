using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.UseCase.Mappings
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventEntity, EventDto>().ReverseMap();
            CreateMap<EventEntity, CreateEventCommand>().ReverseMap();
        }
    }
}
