using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.UseCase.Events.Commands.CreateEvent;
using EventBooking.Application.UseCase.Events.Commands.DeleteEvent;
using EventBooking.Application.UseCase.Events.Commands.UpdateEvent;
using EventBooking.Application.UseCase.Events.Queries.GetAllEvents;
using EventBooking.Application.UseCase.Events.Queries.GetByCountryEvent;
using EventBooking.Application.UseCase.Events.Queries.GetByIdEvent;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.UseCase.Mappings
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventEntity, EventDto>().ReverseMap();
            CreateMap<EventEntity, EventBasicDto>().ReverseMap();
            CreateMap<EventEntity, CreateEventCommand>().ReverseMap();
            CreateMap<EventEntity, UpdateEventCommand>().ReverseMap();
            CreateMap<EventEntity, DeleteEventCommand>().ReverseMap();
            CreateMap<EventEntity, GetAllEventsQuery>().ReverseMap();
            CreateMap<EventEntity, GetByEventCountryQuery>().ReverseMap();
            CreateMap<EventEntity, GetByEventNameQuery>().ReverseMap();
        }
    }
}
