using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class InstructorRepository : IInstructorRepository
    {
        private ApplicationContext _context = new ApplicationContext();

        public async Task CreateInstructor(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
            _context.SaveChanges();
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            return _context.Instructors.ToList();
        }
    }
}
