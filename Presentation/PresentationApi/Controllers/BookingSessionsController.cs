using Application.DTOs.EntityDtos.BookingSession;
using Application.Features.BookingSessions.Commands.DeteleBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSession;
using Features.Application.BookingSessions.Commands.CreateBookginSession;
using Features.Application.BookingSessions.Queries.GetBookingSessionList;
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
        public async Task<ActionResult<List<BookingSessionDto>>> Get()
        {
            var bookingSession = await _mediator.Send(new GetBookingSessionListQuery());
            return Ok(bookingSession);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingSessionDto>> Get(int id)
        {
            var bookingSession = await _mediator.Send(new GetBookingSessionQuery { Id = id });
            return Ok(bookingSession);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateBookingSessionDto bookingSessionDto)
        {
            var bookingSessionId = await _mediator.Send(new CreateBookingSessionCommand { BookingSessionDto = bookingSessionDto });
            return Ok(bookingSessionId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeteleBookingSessionCommand { Id = id } );
            return NoContent();
        }


    }
}
