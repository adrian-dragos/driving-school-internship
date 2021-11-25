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
 public class CreateInstructorCommandListHandler : IRequestHandler<CreateInstructorListCommand, int>
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public CreateInstructorCommandListHandler(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInstructorListCommand command, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(command.instructorDto);
            instructor = await _repository.AddAsync(instructor);
            return instructor.Id;
        }
    }
}
