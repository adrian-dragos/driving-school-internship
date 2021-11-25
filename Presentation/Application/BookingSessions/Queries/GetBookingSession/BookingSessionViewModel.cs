using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Queries.GetBookingSession
{
    public class BookingSessionViewModel
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
