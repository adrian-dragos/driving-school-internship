﻿using Application.DTOs.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<IEnumerable<InsructorDto>>
    {
        public InsructorDto studentDto;
    }
}
