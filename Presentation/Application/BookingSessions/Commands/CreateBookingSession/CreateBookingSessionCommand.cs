using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Commands.CreateBookginSession
{
    public class CreateBookingSessionCommand : IRequest<int>
    {
        public BookingSessionDto bookingSessionDto;
    }
}
