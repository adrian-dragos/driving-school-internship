using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Features.Instructors.Commands.CreateInstructor;
using Application.Features.Instructors.Commands.UpdateEmploymentStatus;
using Application.Features.Instructors.Quieries.GetInstructor;
using Application.Features.Instructors.Quieries.GetInstructorsList;
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
        public async Task<ActionResult<List<InstructorDto>>> GetInstructors()
        {
            var instructors = await _mediator.Send(new GetInstructorListQuery());
            return Ok(instructors);
        }

        [HttpGet("{id}", Name = "GetInstructor")]
        public async Task<ActionResult<InstructorDto>> GetInstructor(int id)
        {
            var instructor = await _mediator.Send(new GetInstructorQuery { Id = id });
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorDto>> CreateInstructor([FromBody] CreateInstructorDto instructorDto)
        {
            var instructor = await _mediator.Send(new CreateInstructorCommand { InstructorDto = instructorDto });
            return CreatedAtRoute("GetInstructor", new { id = instructor.Id }, instructor);
        }

        [HttpPatch("car/{id}")]
        public async Task<ActionResult> UpdateInstructorCar(int id, [FromBody] ChangeInstructorCarDto instructorDto)
        {
            await _mediator.Send(new UpdateInstructorCommand { Id = id, ChangeInstructorCarDto = instructorDto });
            return NoContent();
        }

        [HttpPatch("employment-status/{id}")]
        public async Task<ActionResult> UpdateEmploymentStatus(int id, [FromBody] ChangeInstructorEmploymentStatusDto instructorDto)
        {
            await _mediator.Send(new UpdateInstructorCommand { Id = id, ChangeInstructorEmploymentStatus = instructorDto });
            return NoContent();
        }

    }
}
