using Application.Interfaces;
using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class InstructorRepository : BaseRepository<Instructor>, IInstructorRepository
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

        public  async Task<Instructor> GetInstructorByEmail(string email)
        {
            return await _context.Set<Instructor>().Where(i => i.Email == email).FirstOrDefaultAsync<Instructor>();
        }
    }
}
