using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.CreateBookingSession
{
    public class CreateBookingSessionCommand : IRequest<BookingSessionDto>
    {
        public CreateBookingSessionDto BookingSessionDto { get; set; }
    }
}
