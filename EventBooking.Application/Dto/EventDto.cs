namespace EventBooking.Application.Dto
{
    public record EventDto(string Name, string Country, string Description, DateTime StartDate, int NoOfSeats);
}
