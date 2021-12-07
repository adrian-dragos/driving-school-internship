using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.BookingSessions.Commands.CreateBookginSession
{
    public class CreateBookingSessionCommand : IRequest<int>
    {
        public CreateBookingSessionDto BookingSessionDto { get; set; }
    }
}
