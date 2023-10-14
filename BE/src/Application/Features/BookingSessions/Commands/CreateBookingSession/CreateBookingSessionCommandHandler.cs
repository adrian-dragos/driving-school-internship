using Application.DTOs.EntityDtos.BookingSession;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.CreateBookingSession
{
    public class CreateBookingSessionCommandHandler : IRequestHandler<CreateBookingSessionCommand, BookingSessionDto>
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

        public async Task<BookingSessionDto> Handle(CreateBookingSessionCommand command, CancellationToken cancellationToken)
        {
            var bookginSession = _mapper.Map<BookingSession>(command.BookingSessionDto);
            bookginSession = await _repository.AddAsync(bookginSession);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BookingSessionDto>(bookginSession);
        }
    }
}
