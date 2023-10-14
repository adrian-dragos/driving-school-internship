using Application.DTOs.EntityDtos.BookingSession;
using Application.Features.BookingSessions.Queries.GetStudentBookingListSessions;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetStudentBookingSessionList
{
    public class GetStudentBookingSessionListQueryHandler : IRequestHandler<GetStudentBookingSessionListQuery, IEnumerable<BookingSessionWithNamesDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentBookingSessionListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingSessionWithNamesDto>> Handle(GetStudentBookingSessionListQuery query, CancellationToken cancellationToken)
        {
            var bookingSessions = await _unitOfWork.BookingSessions.GetBookingSessionWithStudentId(query.Id);
            var result = _mapper.Map<List<BookingSessionWithNamesDto>>(bookingSessions);

            foreach (var bookingSession in result)
            {
                var student = await _unitOfWork.Students.GetByIdAsync((bookingSession.StudentId).GetValueOrDefault());
                var instructor = await _unitOfWork.Instructors.GetByIdAsync((bookingSession.InstructorId).GetValueOrDefault());


                bookingSession.StudentFirstName = student.FirstName;
                bookingSession.StudentLastName = student.LastName;

                bookingSession.InstructorFirstName = instructor.FirstName;
                bookingSession.InstructorLastName = instructor.LastName;
            }

            return result;
        }
    }
}

