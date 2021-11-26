using Application.DTOs.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public InstructorDto instructorDto;
    }
}
