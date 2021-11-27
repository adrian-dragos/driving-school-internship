// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Persistance;
using MediatR;
using Application.Common;
using Presentation;
using Features.Application.BookingSessions.Commands.CreateBookginSession;
using Application.Dtos;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.DTOs.BookingSession;
using Features.Application.BookingSessions.Queries.GetBookingSession;

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
