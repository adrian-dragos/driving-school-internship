using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorListCommand : IRequest<int>
    {
        public InstructorDto instructorDto;
    }
}
