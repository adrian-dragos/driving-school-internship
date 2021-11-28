﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class Instructor : User
    {
        public Car? Car { get; set; }
        public int? BookingSessionId { get; set; }
        public virtual BookingSession? GetBookingSessions { get; set; }
    }
}
