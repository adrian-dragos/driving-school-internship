using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task CreateInstructor(Instructor instructor);
        IEnumerable<Instructor> GetInstructors();
    }
}
