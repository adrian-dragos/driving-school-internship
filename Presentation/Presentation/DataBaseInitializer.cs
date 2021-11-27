using Application.DTOs.BookingSession;
using Application.DTOs.Instructor;
using Application.DTOs.Student;
using Features.Application.BookingSessions.Commands.CreateBookginSession;
using Features.Application.BookingSessions.Queries.GetBookingSessionList;
using Features.Application.Instructors.Commands.CreateInstructor;
using Features.Application.Instructors.Quieries.GetInstructorsList;
using Features.Application.Students.Commands.CreateStudent;
using Features.Application.Students.Queries.GetStudentList;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class DataBaseInitializer
    {

        private static async Task IntitializeInstructorDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 3; i++)
            {
                var instructor = new InstructorDto { Name = $"instructor{i}" };
                var instructorId = await mediator.Send(new CreateInstructorCommand { instructorDto = instructor });
            }
        }

        private static async Task InitializeBookginSessionDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 10; i++)
            {
                var bookginSession = new BookingSessionDto
                {
                    StartTime = DateTime.Now,
                    IsAvailable = true
                };
                var bookingSeesionId = await mediator.Send(new CreateBookingSessionCommand { bookingSessionDto = bookginSession });
            }
        }

        private static async Task IntitializeStudentSessionDbAsync(IMediator mediator)
        {
            for (int i = 1; i <= 5; i++)
            {
                var student = new InsructorDto
                {
                    Name = $"student{i}"
                };
                var studentId = await mediator.Send(new CreateStudentCommand { studentDto = student });
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
                Console.WriteLine("\t" + i.Name);
            }
            Console.WriteLine("Succesfull Initialization");


            Console.WriteLine("Intialize BookingSession Database");
            await InitializeBookginSessionDbAsync(mediator);
            var bookingSessions = await mediator.Send(new GetBookingSessionListQuery());
            foreach (var bookingSession in bookingSessions)
            {
                Console.WriteLine("\t" + bookingSession.StartTime + "\t"  + bookingSession.IsAvailable);
            }
            Console.WriteLine("Succesfull BookingSession Initialization");


            Console.WriteLine("Intialize BookingSession Database");
            await IntitializeStudentSessionDbAsync(mediator);
            var students = await mediator.Send(new GetStudentListQuery());
            foreach (var student in students)
            {
                Console.WriteLine("\t" + student.Name);
            }
            Console.WriteLine("Succesful Initialization");
        }
    }
}
