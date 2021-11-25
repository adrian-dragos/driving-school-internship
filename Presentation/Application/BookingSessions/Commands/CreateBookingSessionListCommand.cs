using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Commands
{
    public class CreateBookingSessionListCommand : IRequest<int>
    {
        public BookingSessionDto bookingSessionDto;
    }
}
