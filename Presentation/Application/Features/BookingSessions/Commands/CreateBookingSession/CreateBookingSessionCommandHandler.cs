using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.BookingSessions.Commands.CreateBookginSession
{
    public class CreateBookingSessionCommandHandler : IRequestHandler<CreateBookingSessionCommand, int>
    {
        private readonly IBookingSessionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingSessionCommandHandler(IBookingSessionRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookingSessionCommand command, CancellationToken cancellationToken)
        {
            var bookginSession = _mapper.Map<BookingSession>(command.bookingSessionDto);
            bookginSession = await _repository.AddAsync(bookginSession);
            await _unitOfWork.SaveAsync();
            return bookginSession.Id;
        }
    }
}
