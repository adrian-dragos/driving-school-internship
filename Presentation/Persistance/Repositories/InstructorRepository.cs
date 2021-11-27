using Application.Interfaces;
using Domain.Entities.User;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private ApplicationContext _context;

        public InstructorRepository(ApplicationContext context) : base(context)
        {
        }

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
