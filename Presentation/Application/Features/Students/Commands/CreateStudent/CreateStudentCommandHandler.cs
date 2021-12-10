using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repository;

        public CreateStudentCommandHandler(IStudentRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(command.StudentDto);
            student = await _repository.AddAsync(student);
            await _unitOfWork.SaveAsync();
            return student.Id;
        }
    }
}
