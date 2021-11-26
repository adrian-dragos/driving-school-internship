// See https://aka.ms/new-console-template for more information

using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using MediatR;
using Application.Common;
using Persistance.Repositories;
using AutoMapper;
using System.Reflection;
using Application.DTOs;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Features.Application.Instructors.Commands.CreateInstructor;
using Features.Application.Instructors.Quieries.GetInstructorsList;
using Features.Application.BookingSessions.Commands.CreateBookginSession;
using Features.Application.BookingSessions.Queries.GetBookingSession;
using Features.Application.Students.Commands.CreateStudent;
using Features.Application.Students.Queries.GetStudent;
using Presentation;



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
using (var dbContext = new ApplicationContext())
{
    var isCreated = dbContext.Database.EnsureCreated();
    if (isCreated)
    {
        await DataBaseInitializer.InitializeAsync(mediator);
    }
}