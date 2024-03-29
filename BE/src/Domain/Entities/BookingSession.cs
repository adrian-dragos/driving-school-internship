﻿using Domain.Entities.Common;
using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingSession : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int? InstructorId { get; set; }
        public int? ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public virtual Instructor? Instructors { get; set; }
        public int? StudentId { get; set; }
        public virtual Student? GetStudents { get; set; }
        public static readonly int SessionDurationMin = 90;
    }
}