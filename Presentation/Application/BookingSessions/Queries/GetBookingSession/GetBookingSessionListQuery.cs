﻿using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionListQuery : IRequest<IEnumerable <BookingSessionDto>>
    {
        public BookingSessionDto bookingSessionDto;
    }
}
