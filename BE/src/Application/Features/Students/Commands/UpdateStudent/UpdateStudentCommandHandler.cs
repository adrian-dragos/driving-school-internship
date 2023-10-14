using Application.DTOs.EntityDtos.Person.Student;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(command.StudentDto.Id);

            
            _mapper.Map(command.StudentDto, student);
            await _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
