using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionQuery : IRequest<BookingSessionDto>
    {
        public int Id { get; set; }
    }
}
