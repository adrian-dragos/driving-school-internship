using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability
{
    public class ChangeBookingSessionAvailabilityCommand : IRequest<Unit>
    {
        public ChangeBookingSessionAvailabilityDto changeBookingSessionAvailabilityDto { get; set; }
    } 
}
