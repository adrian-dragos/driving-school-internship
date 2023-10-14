using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionInstructorNameCarNumber
{
    public class GetBoookingSessionInstructorNameCarNumberQuery : IRequest<BookingSessionInstructrorNameCarNumberDto>
    {
        public int Id { get; set; }
    }
}
