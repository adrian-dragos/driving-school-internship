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
                    StartTime = new DateTime(2022, 1, 14, 1, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 6,
                    StartTime = new DateTime(2022, 1, 14, 3, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
            #endregion FullDayOfInstructor1

                new BookingSession
                {
                    Id = 7,
                    StartTime = new DateTime(2022, 1, 11, 4, 30, 0),
                    IsAvailable = false,
                    InstructorId = 2,
                    StudentId = 7
                },
                new BookingSession
                {
                    Id = 8,
                    StartTime = new DateTime(2022, 1, 16, 1, 30, 0),
                    IsAvailable = false,
                    InstructorId = 2,
                    StudentId = 7
                },
                new BookingSession
                {
                    Id = 9,
                    StartTime = new DateTime(2022, 1, 12, 3, 00, 0),
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
                }
            );
        }
    }
}
