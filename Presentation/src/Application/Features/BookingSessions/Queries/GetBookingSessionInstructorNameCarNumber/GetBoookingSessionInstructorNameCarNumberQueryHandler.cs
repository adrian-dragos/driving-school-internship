using Application.DTOs.EntityDtos.BookingSession;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionInstructorNameCarNumber
{
    public class GetBoookingSessionInstructorNameCarNumberQueryHandler : 
        IRequestHandler<GetBoookingSessionInstructorNameCarNumberQuery, BookingSessionInstructrorNameCarNumberDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoookingSessionInstructorNameCarNumberQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingSessionInstructrorNameCarNumberDto> Handle(GetBoookingSessionInstructorNameCarNumberQuery query, 
            CancellationToken cancellationToken)
        {

            var bookingSession = await _unitOfWork.BookingSessions.GetByIdAsync(query.Id);
            var result = _mapper.Map<BookingSessionInstructrorNameCarNumberDto>(bookingSession);

            var instructor = await _unitOfWork.Instructors.GetByIdAsync((result.InstructorId).GetValueOrDefault());
            result.InstructorFirstName = instructor.FirstName;
            result.InstructorLastName = instructor.LastName;
            result.InstructorPhoneNumber = instructor.PhoneNumber;

            var car = await _unitOfWork.Cars.GetByIdAsync((instructor.CarId).GetValueOrDefault());
            result.CarNumber = car.RegistrationNumber;

            return result;
        }
    }
}
