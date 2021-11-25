using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionListQueryHandler : IRequestHandler<GetBookingSessionListQuery, IEnumerable<BookingSessionDto>>
    {
        private readonly IBookingSessionRepository _repository;

        public GetBookingSessionListQueryHandler(IBookingSessionRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<BookingSessionDto>> Handle(GetBookingSessionListQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetBookingSessions().Select(bookingSession => new BookingSessionDto
            {
                StartTime = bookingSession.StartTime,
                IsAvailable = bookingSession.IsAvailable
            });

            return Task.FromResult(result);
        }
    }
}
