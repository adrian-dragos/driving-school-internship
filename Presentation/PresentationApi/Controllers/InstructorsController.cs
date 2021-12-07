using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Features.Instructors.Quieries.GetInstructor;
using Features.Application.Instructors.Commands.CreateInstructor;
using Features.Application.Instructors.Quieries.GetInstructorsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<InstructorDto>>> Get()
        {
            var instructors = await _mediator.Send(new GetInstructorListQuery());
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> Get(int id)
        {
            var instructor = await _mediator.Send(new GetInstructorQuery { Id = id });
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InstructorDto instructorDto)
        {
            var response = await _mediator.Send(new CreateInstructorCommand{ InstructorDto = instructorDto });
            return Ok(response);
        }
    }
}
