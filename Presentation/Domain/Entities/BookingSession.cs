﻿using Domain.Entities.Common;
using Domain.Entities.User;
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
        public bool IsAvailable { get; set; } = false;
        public virtual ICollection<Instructor>? Insturctors { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public static readonly int SessionDurationMin = 90;
    }
}
