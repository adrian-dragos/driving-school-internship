using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, int>
    {
        private readonly IInstructorRepository _repository;

        public CreateInstructorCommandHandler(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = new Instructor
            {
                Name = command.Name
            };

            await _repository.CreateInstructor(instructor);
            return instructor.Id;
        }
    }
}
