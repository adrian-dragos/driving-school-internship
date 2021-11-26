using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingSessionRepository BookingSessions { get; }
        IInstructorRepository Instructors { get; }
        IStudentRepository Students { get; }
        Task Save();
    }
}
