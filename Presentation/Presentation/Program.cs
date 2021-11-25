// See https://aka.ms/new-console-template for more information

using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Application.Instructors.Commands.CreateInstructor;
using MediatR;
using Application.Common;
using Application.Instructors.Quieries.GetInstructorsList;
using Application.BookingSessions.Commands;
using Application.BookingSessions.Queries.GetBookingSession;
using Persistance.Repositories;
using AutoMapper;
using System.Reflection;

Console.WriteLine("Hello, World!");
using (var dbContext = new ApplicationContext())
{
    dbContext.Database.EnsureCreated();
}

var diCotainer = new ServiceCollection()
    .AddAutoMapper(typeof(MappingProfile))
    .AddMediatR(typeof(AssemblyMarker).Assembly)
    .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
    .AddScoped<IInstructorRepository, InstructorRepository>()
    .AddScoped<IBookingSessionRepository, BookingSessionRepository>()
    .BuildServiceProvider();

var mediator = diCotainer.GetRequiredService<IMediator>();
for (int i = 0; i < 5; i++)
{
    var instructor = new InstructorViewModel { Name = $"name{i}" };
    var instructorId = await mediator.Send(new CreateInstructorCommand { InstructorViewModel = instructor });
}

var instructors = await mediator.Send(new GetInstructorsListQuery());
foreach (var i in instructors)
{
    Console.WriteLine(i.Name);
}

for (int i = 0; i < 5; i++)
{
    var bookingSeesionId = await mediator.Send(new CreateBookingSessionCommand
    {
        Startime = DateTime.Now,
        IsAvailable = true
    });
}

var bookingSessions = await mediator.Send(new GetBookingSessionListQuery());
foreach (var bookingSession in bookingSessions)
{
    Console.WriteLine(bookingSession.StartTime);
}
