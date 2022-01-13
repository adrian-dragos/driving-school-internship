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

            Instructor instructor;
            if (query.Email == null)
            {
                instructor = await _repostitory.GetByIdAsync(query.Id);
            }
            else
            {
                instructor = await _repostitory.GetInstructorByEmail(query.Email);
            }
            
            return _mapper.Map<InstructorDto>(instructor);
        }
    }
}
