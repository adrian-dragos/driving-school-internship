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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await _context.Set<Student>().Where(s => s.Email == email).FirstOrDefaultAsync<Student>();
        }
    }
}
