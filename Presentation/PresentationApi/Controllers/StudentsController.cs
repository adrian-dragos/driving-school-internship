using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.Students.Queries.GetStudent;
using Features.Application.Instructors.Quieries.GetInstructorsList;
using Features.Application.Students.Commands.CreateStudent;
using Features.Application.Students.Queries.GetStudentList;
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
        public async Task<ActionResult<List<StudentDto>>> Get()
        {
            var students = await _mediator.Send(new GetStudentListQuery());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var student = await _mediator.Send(new GetStudentQuery { Id = id });
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateStudentDto studentDto)
        {
            var studentId = await _mediator.Send(new CreateStudentCommand { StudentDto = studentDto });
            return Ok(studentId);
        }
    }
}
