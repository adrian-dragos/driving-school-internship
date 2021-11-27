﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Student
{
    public class StudentDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int? BookingSessionId { get; set; }
    }
}
