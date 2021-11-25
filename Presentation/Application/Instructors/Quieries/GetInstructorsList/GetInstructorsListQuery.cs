using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorsListQuery : IRequest<IEnumerable<InstructorViewModel>>
    {
        // public string Name { get; set; }
        public InstructorViewModel instructorViewModel;
    }
}
