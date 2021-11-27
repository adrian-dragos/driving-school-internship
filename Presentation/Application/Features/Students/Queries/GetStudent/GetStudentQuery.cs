using Application.DTOs.User.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentDto>
    {
        public int Id { get; set; } 
    }
}
