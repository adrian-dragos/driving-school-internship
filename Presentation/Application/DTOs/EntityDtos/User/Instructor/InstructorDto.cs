﻿using Application.DTOs.EntityDtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.User.Instructor
{
    public class InstructorDto : UserDto
    {
        public CarDto CarDto { get; set; }
    }
}
