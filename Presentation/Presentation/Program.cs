﻿// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Persistance;
using MediatR;
using Presentation;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.Features.BookingSessions.Queries.GetBookingSession;
using Application.Features.Instructors.Quieries.GetInstructor;
using Application.Features.Students.Queries.GetStudent;
using Application.Features.Car.Commands.ChangeCarAvailability;
using Application.Features.Car.Queries.GetCar;
using Application.DTOs.EntityDtos.Car;
using Application.Features.BookingSessions.Commands.CreateBookingSessionList;
using Application.Configuration;

Console.WriteLine("Hello World");
//var services = new ServiceCollection();
//PersistanceService.ConfigurePersistenceServices(services, null);
//ApplicationService.ConfigureApplicationServices(services);


//var mediator = services.BuildServiceProvider().
//                    GetRequiredService<IMediator>();


//var dbContext = new ApplicationContext();
//dbContext.Database.EnsureDeleted();
//var isCreated = dbContext.Database.EnsureCreated();
//if (isCreated)
//{
//    await DataBaseInitializer.InitializeAsync(mediator);
//}



//var bookginSession = new ChangeBookingSessionAvailabilityDto
//{
//    IsAvailable = false,
//    Id = 4
//};

//var bookingSeesionId = await mediator.Send(new ChangeBookingSessionAvailabilityCommand { changeBookingSessionAvailabilityDto = bookginSession });
//var bookingSessionReceived = await mediator.Send(new GetBookingSessionQuery { Id = 4 });
//Console.WriteLine($"bookingSessionReceived = {bookingSessionReceived.Id} bookingSessionReceived.Availability = {bookingSessionReceived.IsAvailable}");

//var instructor = await mediator.Send(new GetInstructorQuery { Id = 1 });
//Console.WriteLine($"instructorId = {instructor.Id} instructorName = {instructor.FirstName}");

//var student = await mediator.Send(new GetStudentQuery { Id = 4 });
//Console.WriteLine($"studentId = {student.Id} studentName = {student.FirstName}");

//var car = new ChangeCarAvailabilityDto
//{
//    IsAvailable = false,
//    Id = 2
//};

//var carId = await mediator.Send(new ChangeCarAvailabilityCommand { changeCarAvailabilityDto = car });
//var carReceived = await mediator.Send(new GetCarQuery { Id = 4 });
//Console.WriteLine($"carReceived = {car.Id} carReceived.Availability = {car.IsAvailable}");

//var bookingSessionList = new List<BookingSessionDto>();
//for (int i = 1; i <= 2; i++)
//{
//    bookingSessionList.Add(new BookingSessionDto
//    {
//        StartTime = DateTime.Now,
//        IsAvailable = true,
//        InstructorId = 1
//    });
//}

//var ids = await mediator.Send(new CreateBookingSessionListCommand { bookingSessionsDto = bookingSessionList });
//foreach (var id in ids)
//{
//    Console.WriteLine(id);
//}