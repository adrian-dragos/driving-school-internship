using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorsListQueryHandler : IRequestHandler<GetInstructorsListQuery, IEnumerable<InstructorViewModel>>
    {
        private readonly IInstructorRepository _repository;

        public GetInstructorsListQueryHandler(IInstructorRepository instructorRepository)
        {
            _repository = instructorRepository;
        }

       
        public Task<IEnumerable<InstructorViewModel>> Handle(GetInstructorsListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetInstructors().Select(instructor => new InstructorViewModel
            {
                Name = instructor.Name
            });

            return Task.FromResult(result);
        }
    }
}
