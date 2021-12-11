using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.CreateInstructor
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, InstructorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public CreateInstructorCommandHandler(IUnitOfWork unitOfWork, IInstructorRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InstructorDto> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(command.InstructorDto);
            instructor = await _repository.AddAsync(instructor);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<InstructorDto>(instructor); 
        }
    }
}
