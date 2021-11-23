using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Commands
{
    public class CreateBookingSessionCommand : IRequest<int>
    {
        public DateTime Startime { get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
