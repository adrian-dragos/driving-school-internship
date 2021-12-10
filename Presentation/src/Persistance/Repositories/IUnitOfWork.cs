using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            BookingSessions = new BookingSessionRepository(_context);
            Instructors = new InstructorRepository(_context);
            Students = new StudentRepository(_context);
        }

        public IBookingSessionRepository BookingSessions { get; private set; }
        public IInstructorRepository Instructors { get; private set; }
        public IStudentRepository Students { get; private set; }
        
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
