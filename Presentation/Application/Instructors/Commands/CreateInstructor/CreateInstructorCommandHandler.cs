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
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public CreateInstructorCommandHandler(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(command.InstructorViewModel);
            instructor = await _repository.AddAsync(instructor);
            return instructor.Id;
            //var instructor = new Instructor
            //{
            //    Name = command.Name
            //};

            //await _repository.AddAsync(instructor);
            //return instructor.Id;
        }
    }
}
