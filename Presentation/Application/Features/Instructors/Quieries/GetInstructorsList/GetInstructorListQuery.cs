using Application.DTOs.EntityDtos.Person.Instructor;
using MediatR;

namespace Features.Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorListQuery : IRequest<IEnumerable<InstructorDto>>
    {
        public InstructorDto InstructorDto { get; set; }
    }
}
