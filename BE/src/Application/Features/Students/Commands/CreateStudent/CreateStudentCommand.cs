﻿using Application.DTOs.EntityDtos.Person.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        public CreateStudentDto StudentDto { get; set; }
    }
}
