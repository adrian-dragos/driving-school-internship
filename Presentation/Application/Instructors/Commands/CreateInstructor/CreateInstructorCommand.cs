using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorCommand : IRequest<int>
    {
        //public InstructorDto instructorDto;
        public int BookingSessionId { get; set; }
        public string Name { get; set; }
    }
}
