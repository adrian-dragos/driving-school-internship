using Application.DTOs.EntityDtos.Person.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public CreateInstructorDto InstructorDto { get; set; }
    }
}
