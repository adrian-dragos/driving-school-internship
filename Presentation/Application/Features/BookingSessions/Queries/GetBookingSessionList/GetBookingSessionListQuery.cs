using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionList
{
    public class GetBookingSessionListQuery : IRequest<IEnumerable<BookingSessionDto>>
    {
        public BookingSessionDto BookingSessionDto { get; set; }
    }
}
