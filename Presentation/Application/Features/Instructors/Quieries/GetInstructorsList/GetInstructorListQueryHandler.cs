using Application.DTOs.User.Instructor;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorListQueryHandler : IRequestHandler<GetInstructorListQuery, IEnumerable<InstructorDto>>
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public GetInstructorListQueryHandler(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDto>> Handle(GetInstructorListQuery query, CancellationToken cancellationToken)
        {
            var instructor = await _repository.GetAll();
            return _mapper.Map<List<InstructorDto>>(instructor);
        }
    }
}
