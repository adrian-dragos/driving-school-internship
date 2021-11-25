using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookingSessions.Commands
{
    public class CreateBookingSessionListCommandHandler : IRequestHandler<CreateBookingSessionListCommand, int>
    {
        private readonly IBookingSessionRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookingSessionListCommandHandler(IBookingSessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookingSessionListCommand command, CancellationToken cancellationToken)
        {
            var bookginSession = _mapper.Map<BookingSession>(command.bookingSessionDto);
            bookginSession = await _repository.AddAsync(bookginSession);
            return bookginSession.Id;
        }
    }
}
