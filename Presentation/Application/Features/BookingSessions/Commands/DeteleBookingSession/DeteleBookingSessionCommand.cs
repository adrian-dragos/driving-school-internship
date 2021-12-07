using Application.DTOs.EntityDtos.BookingSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.DeteleBookingSession
{
    public class DeteleBookingSessionCommand : IRequest<Unit>
    {
       public int Id { get; set; }
    }
}
