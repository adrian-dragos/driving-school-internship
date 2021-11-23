using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionListQueryHandler : IRequestHandler<GetBookingSessionListQuery, IEnumerable<BookingSessionViewModel>>
    {
        private readonly IBookingSessionRepository _repository;

        public GetBookingSessionListQueryHandler(IBookingSessionRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<BookingSessionViewModel>> Handle(GetBookingSessionListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetBookingSessions().Select(bookingSession => new BookingSessionViewModel
            {
                Id = bookingSession.Id,
              //  StartTime = bookingSession.StartTime,
                IsAvailable = bookingSession.IsAvailable
            });

            return Task.FromResult(result);
        }
    }
}
