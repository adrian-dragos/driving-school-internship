using Application.DTOs.EntityDtos.Person.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetStudentsList
{
    public class GetStudentListQuery : IRequest<IEnumerable<StudentDto>>
    {
        public StudentDto StudentDto { get; set; }
    }
}
