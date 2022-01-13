using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BookingSessionRepository : BaseRepository<BookingSession>, IBookingSessionRepository
    {
        private ApplicationContext _context;

        public BookingSessionRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateBookingSession(BookingSession bookingSession)
        {
            await _context.BookingSessions.AddAsync(bookingSession);
            _context.SaveChanges();
        }
        
        public IEnumerable<BookingSession> GetBookingSessions()
        {
            return _context.BookingSessions;
        }

        public async Task<IEnumerable<BookingSession>> GetBookingSessionWithStudentId(int id)
        {
            return await _context.BookingSessions.Where(b => b.StudentId ==id).OrderByDescending(x => x.StartTime).ToListAsync(); ;
        }
    }
}
    