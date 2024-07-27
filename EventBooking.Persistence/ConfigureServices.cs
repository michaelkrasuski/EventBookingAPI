using EventBooking.Application.Interface.Persistence;
using EventBooking.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventBooking.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services) 
        {
            services.AddDbContext<EventBookingDbContext>(options => options.UseInMemoryDatabase("EventBookingDb"));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }   
    }
}
