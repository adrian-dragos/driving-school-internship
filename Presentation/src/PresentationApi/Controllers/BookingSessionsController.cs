using Application.DTOs.EntityDtos.BookingSession;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.Features.BookingSessions.Commands.CreateBookingSession;
using Application.Features.BookingSessions.Commands.CreateBookingSessionList;
using Application.Features.BookingSessions.Commands.DeteleBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSessionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingSessionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingSessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookinSessionInstructorNameCarDto>>> GetBookingSessions()
        {
            var bookingSession = await _mediator.Send(new GetBookingSessionListQuery());
            return Ok(bookingSession);
        }

        [HttpGet("{id}", Name = "GetBookingSession")]
        public async Task<ActionResult<BookingSessionWithNamesDto>> GetBookingSession(int id)
        {
            var bookingSession = await _mediator.Send(new GetBookingSessionQuery { Id = id });
            return Ok(bookingSession);
        }

        [HttpPost("booking-session")]
        public async Task<ActionResult<BookingSessionDto>> CreateBookingSession([FromBody] CreateBookingSessionDto bookingSessionDto)
        {
            var bookingSession = await _mediator.Send(new CreateBookingSessionCommand { BookingSessionDto = bookingSessionDto });
            return CreatedAtRoute("GetBookingSession", new { id = bookingSession.Id }, bookingSession);
        }

        [HttpPost("booking-sessions")]
        public async Task<ActionResult<List<BookingSessionDto>>> CreateBookingSessions([FromBody] IEnumerable<CreateBookingSessionDto> bookingSessionDto)
        {
            var bookingSessions = await _mediator.Send(new CreateBookingSessionListCommand { BookingSessionsDto = bookingSessionDto });
            return CreatedAtAction("CreateBookingSessions", bookingSessions);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeLessonAvailability(int id, [FromBody] ChangeBookingSessionAvailabilityDto bookingSessionDto)
        {
            await _mediator.Send(new ChangeBookingSessionAvailabilityCommand { Id = id, ChangeBookingSessionAvailabilityDto = bookingSessionDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookingSession(int id)
        {
            await _mediator.Send(new DeteleBookingSessionCommand { Id = id } );
            return NoContent();
        }
    }
}
