using Application.DTOs.EntityDtos.BookingSession;
using Application.DTOs.EnumDtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionList
{
    public class GetBookingSessionListQueryHandler : IRequestHandler<GetBookingSessionListQuery, IEnumerable<BookinSessionInstructorNameCarDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingSessionListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookinSessionInstructorNameCarDto>> Handle(GetBookingSessionListQuery query, CancellationToken cancellationToken)
        {
            var bookingSessions = await _unitOfWork.BookingSessions.GetAll();
            var result = _mapper.Map<List<BookinSessionInstructorNameCarDto>>(bookingSessions);

            foreach (var bookingSession in result)
            {
                var instructor = await _unitOfWork.Instructors.GetByIdAsync(bookingSession.InstructorId.GetValueOrDefault());
                bookingSession.InstructorFirstName = instructor.FirstName;
                bookingSession.InstructorLastName = instructor.LastName;

                var car  = await _unitOfWork.Cars.GetByIdAsync(instructor.CarId.GetValueOrDefault());
                bookingSession.CarModel =  _mapper.Map<CarModelTypeDto>(car.CarModelType); 
                bookingSession.CarGear = _mapper.Map<CarGearDto>(car.CarGear);
            }
            return result;
        }
    }
}
