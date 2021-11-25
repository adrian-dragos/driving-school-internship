using Application.Instructors.Quieries.GetInstructorsList;
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
        public InstructorViewModel InstructorViewModel;
        //public int BookingSessionId { get; set; }
        //public string Name { get; set; }
    }
}
