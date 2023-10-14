using Application.DTOs.EntityDtos.BookingSession;
using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.BookingSessions.Queries.GetStudentBookingListSessions;
using Application.Features.Students.Commands.CreateStudent;
using Application.Features.Students.Commands.UpdateStudent;
using Application.Features.Students.Queries.GetStudent;
using Application.Features.Students.Queries.GetStudentsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentListQuery());
            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _mediator.Send(new GetStudentQuery { Id = id });
            return Ok(student);
        }

        [HttpGet("email")]
        public async Task<ActionResult<StudentDto>> GetStudentByEmail(string email)
        {
            var student = await _mediator.Send(new GetStudentQuery { Email = email });
            return Ok(student);
        }

        [HttpGet("bookingSessions")]
        public async Task<ActionResult<BookingSessionWithNamesDto>> GetStudentBookingSessions(int id)
        {
            var student = await _mediator.Send(new GetStudentBookingSessionListQuery { Id = id });
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] CreateStudentDto studentDto)
        {
            var student = await _mediator.Send(new CreateStudentCommand { StudentDto = studentDto });
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }




        [HttpPatch("student")]
        public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentProfileDto studentDto)
        {
            await _mediator.Send(new UpdateStudentCommand { StudentDto = studentDto });
            return NoContent();
        }
    }
}
