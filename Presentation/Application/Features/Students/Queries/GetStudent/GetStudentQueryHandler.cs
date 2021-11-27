using Application.DTOs.User.Student;
using Application.Interfaces;
using AutoMapper;
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
            var student = await _repository.GetByIdAsync(query.Id);
            return _mapper.Map<StudentDto>(student);
        }
    }
}
