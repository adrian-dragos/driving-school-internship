using Application.DTOs.Instructor;
using Application.DTOs.Student;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Quieries.GetInstructor
{

    public class GetBookingSessionQueryHandler : IRequestHandler<GetInstructorQuery, InstructorDto>
    {
        private readonly IInstructorRepository _repostitory;
        private readonly IMapper _mapper;

        public GetBookingSessionQueryHandler(IInstructorRepository repostitory, IMapper mapper)
        {
            _repostitory = repostitory;
            _mapper = mapper;
        }

        public async Task<InstructorDto> Handle(GetInstructorQuery query, CancellationToken cancellationToken)
        {
            var instructor = await _repostitory.GetByIdAsync(query.Id);
            return _mapper.Map<InstructorDto>(instructor);
        }
    }
}
