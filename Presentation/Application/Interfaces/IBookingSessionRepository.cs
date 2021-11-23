using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookingSessionRepository
    {
        public Task CreateBookingSession(BookingSession bookingSession);
        public IEnumerable<BookingSession> GetBookingSessions();
    }
}
