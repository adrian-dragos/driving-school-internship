using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Entities
{
    public class BookingSessionConfiguration : IEntityTypeConfiguration<BookingSession>
    {
        public void Configure(EntityTypeBuilder<BookingSession> builder)
        {
            builder.HasData(
            #region FullDayOfInstructor1
                new BookingSession
                {
                    Id = 1,
                    StartTime = new DateTime(2022, 1, 14, 7, 0, 0),
                    IsAvailable = false,
                    InstructorId = 1,
                    StudentId = 7,
                },
                new BookingSession
                {
                    Id = 2,
                    StartTime = new DateTime(2022, 1, 14, 8, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 3,
                    StartTime =  new DateTime(2022, 1, 14, 10, 0, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 4,
                    StartTime = new DateTime(2022, 1, 14, 11, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 5,
                    StartTime = new DateTime(2022, 1, 14, 13, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 6,
                    StartTime = new DateTime(2022, 1, 14, 15, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
            #endregion FullDayOfInstructor1

                new BookingSession
                {
                    Id = 7,
                    StartTime = new DateTime(2022, 1, 16, 16, 30, 0),
                    IsAvailable = false,
                    InstructorId = 2,
                    StudentId = 7
                },
                new BookingSession
                {
                    Id = 8,
                    StartTime = new DateTime(2022, 1, 16, 13, 30, 0),
                    IsAvailable = false,
                    InstructorId = 2,
                    StudentId = 7
                },
                new BookingSession
                {
                    Id = 9,
                    StartTime = new DateTime(2022, 1, 12, 15, 00, 0),
                    IsAvailable = false,
                    InstructorId = 4,
                    StudentId = 7
                },
                new BookingSession
                {
                    Id = 10,
                    StartTime = new DateTime(2022, 1, 14, 11, 30, 0),
                    IsAvailable = true,
                    InstructorId = 5,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 11,
                    StartTime = new DateTime(2022, 1, 13, 18, 30, 0),
                    IsAvailable = true,
                    InstructorId = 5,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 12,
                    StartTime = new DateTime(2022, 1, 15, 10, 30, 0),
                    IsAvailable = true,
                    InstructorId = 3,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 13,
                    StartTime = new DateTime(2022, 1, 15, 15, 30, 0),
                    IsAvailable = true,
                    InstructorId = 2,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 14,
                    StartTime = new DateTime(2022, 1, 15, 12, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 15,
                    StartTime = new DateTime(2022, 1, 15, 16, 30, 0),
                    IsAvailable = true,
                    InstructorId = 4,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 16,
                    StartTime = new DateTime(2022, 1, 16, 14, 30, 0),
                    IsAvailable = true,
                    InstructorId = 2,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 17,
                    StartTime = new DateTime(2022, 1, 16, 13, 00, 0),
                    IsAvailable = true,
                    InstructorId = 2,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 18,
                    StartTime = new DateTime(2022, 1, 16, 10, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null
                },
                 new BookingSession
                 {
                     Id = 19,
                     StartTime = new DateTime(2022, 1, 15, 15, 30, 0),
                     IsAvailable = true,
                     InstructorId = 2,
                     StudentId = null
                 },
                new BookingSession
                {
                    Id = 20,
                    StartTime = new DateTime(2022, 1, 15, 12, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 21,
                    StartTime = new DateTime(2022, 1, 17, 14, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 22,
                    StartTime = new DateTime(2022, 1, 17, 13, 00, 0),
                    IsAvailable = true,
                    InstructorId = 4,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 23,
                    StartTime = new DateTime(2022, 1, 17, 10, 00, 0),
                    IsAvailable = true,
                    InstructorId = 5,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 24,
                    StartTime = new DateTime(2022, 1, 17, 16, 30, 0),
                    IsAvailable = true,
                    InstructorId = 2,
                    StudentId = null
                },
                  new BookingSession
                  {
                      Id = 25,
                      StartTime = new DateTime(2022, 1, 18, 10, 00, 0),
                      IsAvailable = true,
                      InstructorId = 5,
                      StudentId = null
                  },
                new BookingSession
                {
                    Id = 26,
                    StartTime = new DateTime(2022, 1, 18, 14, 30, 0),
                    IsAvailable = true,
                    InstructorId = 3,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 27,
                    StartTime = new DateTime(2022, 1, 18, 13, 00, 0),
                    IsAvailable = true,
                    InstructorId = 4,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 28,
                    StartTime = new DateTime(2022, 1, 18, 12, 00, 0),
                    IsAvailable = true,
                    InstructorId = 2,
                    StudentId = null
                },
                new BookingSession
                {
                    Id = 29,
                    StartTime = new DateTime(2022, 1, 18, 16, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null
                }
            );
        }
    }
}
