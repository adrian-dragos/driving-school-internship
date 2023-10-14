using Application.DTOs.EntityDtos.Person.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public UpdateStudentProfileDto StudentDto { get; set; }
    }
}
