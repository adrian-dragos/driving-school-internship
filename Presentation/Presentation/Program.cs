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
using Presentation;



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