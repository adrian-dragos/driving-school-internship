using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries.GetStudent
{
    public class GetStudentListQuery : IRequest<IEnumerable<StudentDto>>
    {
        public StudentDto studentDto;
    }
}
