﻿using Application.Features.Car.Commands.CreateCar;
using Application.Features.Car.Queries.GetCarList;
using Features.Application.BookingSessions.Commands.CreateBookginSession;
using Features.Application.BookingSessions.Queries.GetBookingSessionList;
using Features.Application.Instructors.Commands.CreateInstructor;
using Features.Application.Instructors.Quieries.GetInstructorsList;
using Features.Application.Students.Commands.CreateStudent;
using Features.Application.Students.Queries.GetStudentList;
using Application.DTOs.EnumDtos;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.EntityDto.BookingSession;
using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EntityDtos.Person.Instructor;
using Application.DTOs.EntityDtos.Person.Student;

namespace Presentation
{
    public class DataBaseInitializer
    {

        private static async Task IntitializeInstructorDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 3; i++)
            {
                var instructor = new InstructorDto {
                    FirstName = $"instructor{i}",
                    LastName = $"instructor{i}",
                    Email = $"instructor_email{i}",
                    PhoneNumber = $"0{i}{i}{i}",
                    Birthday = DateTime.Now
                };
                var instructorId = await mediator.Send(new CreateInstructorCommand { instructorDto = instructor });
            }
        }

        private static async Task InitializeBookginSessionDbAsync(IMediator mediator)
        {
            var rand = new Random();
            for (int i = 1; i <= 15; i++)
            {
                var bookginSession = new BookingSessionDto
                {
                    StartTime = DateTime.Now,
                    IsAvailable = true,
                    InstructorId = rand.Next(1, 3),
                    StudentId = rand.Next(1, 5)
                };
                var bookingSeesionId = await mediator.Send(new CreateBookingSessionCommand { bookingSessionDto = bookginSession });
            }
        }

        private static async Task IntitializeStudentSessionDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 5; i++)
            {
                var student = new StudentDto
                {
                    FirstName = $"student{i}",
                    LastName = $"student{i}",
                    Email = $"student_email{i}",
                    PhoneNumber = $"0{i}{i}{i}",
                    Birthday = DateTime.Now
                };
                var studentId = await mediator.Send(new CreateStudentCommand { studentDto = student });
            }
        }

        private static async Task IntitializeCarDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 5; i++)
            {
                var car = new CarDto
                {
                    CarFabricationTime = DateTime.Now,
                    RegistrationNumber = $"TM {i}",
                    IsAvaibale = true
                };
                if (i < 4)
                {
                    car.CarModelType = CarModelTypeDto.DaciaLogan;
                    car.CarGear = CarGearDto.Automatic;
                    car.InstructorId = i;
                }
                else
                {
                    car.CarModelType = CarModelTypeDto.RenaultZoe;
                    car.CarGear = CarGearDto.Manual;
                }
                var carId = await mediator.Send(new CreateCarCommand { carDto = car });
            }
        }

        public static async Task InitializeAsync(IMediator mediator)
        {
            Console.WriteLine("Intialize Database");


            Console.WriteLine("Intialize Instructors Database");
            await IntitializeInstructorDbAsync(mediator);
            var instructors = await mediator.Send(new GetInstructorListQuery());
            foreach (var i in instructors)
            {
                Console.WriteLine("\t" + i.FirstName);
            }
            Console.WriteLine("Succesfull Initialization");


            Console.WriteLine("Intialize Car Database");
            await IntitializeCarDbAsync(mediator);
            var cars = await mediator.Send(new GetCarListQuery());
            foreach (var car in cars)
            {
                Console.WriteLine("\t" + car.RegistrationNumber);
            }
            Console.WriteLine("Succesful Initialization");

            Console.WriteLine("Intialize Students Database");
            await IntitializeStudentSessionDbAsync(mediator);
            var students = await mediator.Send(new GetStudentListQuery());
            foreach (var student in students)
            {
                Console.WriteLine("\t" + student.FirstName);
            }
            Console.WriteLine("Succesful Initialization");

            Console.WriteLine("Intialize BookingSession Database");
            await InitializeBookginSessionDbAsync(mediator);
            var bookingSessions = await mediator.Send(new GetBookingSessionListQuery());
            foreach (var bookingSession in bookingSessions)
            {
                Console.WriteLine("\t" + bookingSession.StartTime + "\t" + bookingSession.IsAvailable);
            }
            Console.WriteLine("Succesfull BookingSession Initialization");
        }
    }
}
