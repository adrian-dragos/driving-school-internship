// See https://aka.ms/new-console-template for more information

using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Application.Instructors.Commands.CreateInstructor;
using MediatR;
using Application.Common;
using Application.Instructors.Quieries.GetInstructorsList;
using Application.BookingSessions.Queries.GetBookingSession;
using Persistance.Repositories;
using AutoMapper;
using System.Reflection;
using Application.DTOs;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Application.Students.Commands.CreateStudent;
using Application.Students.Queries.GetStudent;
using Application.BookingSessions.Commands.CreateBookginSession;

Console.WriteLine("Hello, World!");
using (var dbContext = new ApplicationContext())
{
    dbContext.Database.EnsureCreated();
}

var diCotainer = new ServiceCollection()
    .AddDbContextFactory<ApplicationContext>()
    .AddAutoMapper(typeof(MappingProfile))
    .AddMediatR(typeof(AssemblyMarker).Assembly)
    .AddTransient<IUnitOfWork, UnitOfWork>()
    .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
    .AddScoped<IInstructorRepository, InstructorRepository>()
    .AddScoped<IBookingSessionRepository, BookingSessionRepository>()
    .AddScoped<IStudentRepository, StudentRepository>()
    .BuildServiceProvider();

var mediator = diCotainer.GetRequiredService<IMediator>();
for (int i = 0; i < 5; i++)
{
    var instructor = new InstructorDto { Name = $"name{i}" };
    var instructorId = await mediator.Send(new CreateInstructorCommand { instructorDto = instructor });
}

var instructors = await mediator.Send(new GetInstructorListQuery());
foreach (var i in instructors)
{
    Console.WriteLine(i.Name);
}

for (int i = 0; i < 5; i++)
{
    var bookginSession = new BookingSessionDto
    {
        StartTime = DateTime.Now,
        IsAvailable = true
    };
    var bookingSeesionId = await mediator.Send(new CreateBookingSessionCommand { bookingSessionDto = bookginSession });
}

var bookingSessions = await mediator.Send(new GetBookingSessionListQuery());
foreach (var bookingSession in bookingSessions)
{
    Console.WriteLine(bookingSession.StartTime);
}

for (int i = 0; i < 5;  i++)
{
    var student = new StudentDto
    {
        Name = $"name{i + 10}"
    };
    var studentId = await mediator.Send(new CreateStudentCommand { studentDto = student });
}

var students = await mediator.Send(new GetStudentListQuery());
foreach (var student in students)
{
    Console.WriteLine(student.Name);
}