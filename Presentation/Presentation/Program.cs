// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Persistance;
using MediatR;
using Application.Common;
using Presentation;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.DTOs.BookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSession;

var services = new ServiceCollection();
PersistanceService.ConfigurePersistenceServices(services);
ApplicationService.ConfigurePersistenceServices(services);


var mediator = services.BuildServiceProvider().
                    GetRequiredService<IMediator>();

using (var dbContext = new ApplicationContext())
{
    var isCreated = dbContext.Database.EnsureCreated();
    if (isCreated)
    {
        await DataBaseInitializer.InitializeAsync(mediator);
    }
}


var bookginSession = new ChangeBookingSessionAvailabilityDto
{
    IsAvailable = false,
    Id = 4
};

var bookingSeesionId = await mediator.Send(new ChangeBookingSessionAvailabilityCommand { changeBookingSessionAvailabilityDto = bookginSession });
var bookingSessionReceived = await mediator.Send(new GetBookingSessionQuery { Id = 4 });
Console.WriteLine($"bookingSessionReceived = {bookingSessionReceived.Id} bookingSessionReceived.Avaibilaty = {bookingSessionReceived.IsAvailable}");
