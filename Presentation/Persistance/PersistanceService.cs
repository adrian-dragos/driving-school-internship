﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceService
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddDbContextFactory<ApplicationContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IInstructorRepository, InstructorRepository>()
                .AddScoped<IBookingSessionRepository, BookingSessionRepository>()
                .AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}