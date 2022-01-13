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

namespace Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repository;

        public GetStudentQueryHandler(IMapper mapper, IStudentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<StudentDto> Handle(GetStudentQuery query, CancellationToken cancellationToken)
        {

            Student student;
            if (query.Email == null)
            {
                student = await _repository.GetByIdAsync(query.Id);
            }
            else
            {
                student = await _repository.GetStudentByEmail(query.Email);
            }
            return _mapper.Map<StudentDto>(student);
        }
    }
}
