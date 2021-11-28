using Application.DTOs.EntityDtos.User.Student;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.Students.Queries.GetStudent
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, IEnumerable<StudentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repository;

        public GetStudentListHandler(IMapper mapper, IUnitOfWork unitOfWork, IStudentRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            var student = await _repository.GetAll();
            return _mapper.Map<List<StudentDto>>(student);
        }
    }
}
