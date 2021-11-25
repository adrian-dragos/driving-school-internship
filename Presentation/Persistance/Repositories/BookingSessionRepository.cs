using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BookingSessionRepository : GenericRepository<BookingSession>, IBookingSessionRepository
    {
        private ApplicationContext _context = new ApplicationContext();

        public async Task CreateBookingSession(BookingSession bookingSession)
        {
            await _context.BookingSessions.AddAsync(bookingSession);
            _context.SaveChanges();
        }
        
        public IEnumerable<BookingSession> GetBookingSessions()
        {
            return _context.BookingSessions.ToList();
        }
    }
}
