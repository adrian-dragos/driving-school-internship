using Application.DTOs.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Quieries.GetInstructor
{
    public class GetInstructorQuery : IRequest<InstructorDto>
    {
        public int Id { get; set; }   
    }
}
