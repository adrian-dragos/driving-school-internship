using Application.DTOs.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorListQuery : IRequest<IEnumerable<InstructorDto>>
    {
        public InstructorDto instructorDto;
    }
}
