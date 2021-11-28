using Application.DTOs.EntityDto.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.BookingSessions.Queries.GetBookingSessionList
{
    public class GetBookingSessionListQuery : IRequest<IEnumerable <BookingSessionDto>>
    {
        public BookingSessionDto bookingSessionDto;
    }
}
