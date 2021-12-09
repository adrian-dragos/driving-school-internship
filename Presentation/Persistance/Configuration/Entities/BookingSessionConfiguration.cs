﻿using Domain.Entities;
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
            builder.ToTable("BookingSessions");
            builder.HasData(
            #region FullDayOfInstructor1
                new BookingSession
                {
                    Id = 1,
                    StartTime = new DateTime(2021, 12, 12, 7, 0, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 2,
                    StartTime = new DateTime(2021, 12, 12, 8, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 3,
                    StartTime =  new DateTime(2021, 12, 12, 10, 0, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 4,
                    StartTime = new DateTime(2021, 12, 12, 11, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 5,
                    StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 6,
                    StartTime = new DateTime(2021, 12, 12, 3, 00, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
            #endregion FullDayOfInstructor1

                new BookingSession
                {
                    Id = 7,
                    StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                    IsAvailable = true,
                    InstructorId = 1,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 8,
                    StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
                    IsAvailable = true,
                    InstructorId = 3,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 9,
                    StartTime = new DateTime(2021, 12, 12, 3, 00, 0),
                    IsAvailable = true,
                    InstructorId = 4,
                    StudentId = null,
                },
                new BookingSession
                {
                    Id = 10,
                    StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                    IsAvailable = true,
                    InstructorId = 5,
                    StudentId = null,
                }
                );
        }
    }
}