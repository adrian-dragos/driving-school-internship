using Application.DTOs.EntityDtos.Person.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.UpdateEmploymentStatus
{
    public class UpdateInstructorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ChangeInstructorEmploymentStatusDto ChangeInstructorEmploymentStatus { get; set; }
        public ChangeInstructorCarDto ChangeInstructorCarDto { get; set; }
    }
}
