using Application.DTOs.EntityDtos.BookingSession;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionQueryHandler : IRequestHandler<GetBookingSessionQuery, BookingSessionWithNamesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingSessionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingSessionWithNamesDto> Handle(GetBookingSessionQuery query, CancellationToken cancellationToken)
        {
            var bookingSession = await _unitOfWork.BookingSessions.GetByIdAsync(query.Id);
            var result = _mapper.Map<BookingSessionWithNamesDto>(bookingSession);
            var student = await _unitOfWork.Students.GetByIdAsync((result.StudentId).GetValueOrDefault());
            var instructor = await _unitOfWork.Instructors.GetByIdAsync((result.InstructorId).GetValueOrDefault());


            result.StudentFirstName = student.FirstName;
            result.StudentLastName = student.LastName;

            result.InstructorFirstName = instructor.FirstName;
            result.InstructorLastName = instructor.LastName;

            return result;
        }
    }
}
