using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.Students.Commands.CreateStudent;
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

        [HttpPost]
        public async Task<ActionResult<int>> CreateStudent([FromBody] CreateStudentDto studentDto)
        {
            var studentId = await _mediator.Send(new CreateStudentCommand { StudentDto = studentDto });
            return Ok(studentId);
        }
    }
}
