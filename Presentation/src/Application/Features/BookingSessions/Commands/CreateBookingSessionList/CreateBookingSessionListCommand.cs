using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.CreateBookingSessionList
{
    public class CreateBookingSessionListCommand : IRequest<IEnumerable<int>>
    {
        public IEnumerable<CreateBookingSessionDto> BookingSessionsDto { get; set; }
    }
}
