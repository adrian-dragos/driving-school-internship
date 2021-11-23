using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Commands
{
    public class CreateBookingSessionCommandHandler : IRequestHandler<CreateBookingSessionCommand, int>
    {
        private readonly IBookingSessionRepository _repository;

        public CreateBookingSessionCommandHandler(IBookingSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBookingSessionCommand command, CancellationToken cancellationToken)
        {
            var bookingSession = new BookingSession
            {
                StartTime = command.Startime,
                IsAvailable = command.IsAvailable
            };

            await _repository.CreateBookingSession(bookingSession);
            return bookingSession.Id;
        }
    }
}
