using Application.Interfaces;
using AutoMapper;
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
        //private readonly IInstructorRepository _repository;
        private readonly IGenericRepository<Instructor> _repository;

        //public CreateInstructorCommandHandler(IInstructorRepository repository)
        //{
        //    _repository = repository;
        //}

        public CreateInstructorCommandHandler(IGenericRepository<Instructor> repository)
        {
            _repository = repository;
        }


        public async Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = new Instructor
            {
                Name = command.Name
            };

            await _repository.AddAsync(instructor);
            return instructor.Id;
        }
    }
}
