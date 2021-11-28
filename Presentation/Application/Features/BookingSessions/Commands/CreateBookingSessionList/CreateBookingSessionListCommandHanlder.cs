using Application.DTOs.EntityDto.BookingSession;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.CreateBookingSessionList
{
    public class CreateBookingSessionListCommandHanlder : IRequestHandler<CreateBookingSessionListCommand, IEnumerable<int>>
    {
        private readonly IBookingSessionRepository _bookingSessionRepository;        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingSessionListCommandHanlder(IBookingSessionRepository bookingSessionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookingSessionRepository = bookingSessionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<int>> Handle(CreateBookingSessionListCommand command, CancellationToken cancellationToken)
        {
            var bookingSessions = _mapper.Map<List<BookingSession>>(command.bookingSessionsDto);
            var bookingSessionsCreated = await _bookingSessionRepository.AddRangeAsync(bookingSessions);
            var result = new List<int>();
            await _unitOfWork.SaveAsync();
            foreach (var b in bookingSessionsCreated)
            {
                result.Add(b.Id);
            }
            return result;
        }
    }
}
