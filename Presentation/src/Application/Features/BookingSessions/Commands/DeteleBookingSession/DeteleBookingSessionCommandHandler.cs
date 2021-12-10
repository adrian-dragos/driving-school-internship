using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.DeteleBookingSession
{
    public class DeteleBookingSessionCommandHandler : IRequestHandler<DeteleBookingSessionCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeteleBookingSessionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeteleBookingSessionCommand command, CancellationToken cancellationToken)
        {
            var bookingSesson = await _unitOfWork.BookingSessions.GetByIdAsync(command.Id);
            await _unitOfWork.BookingSessions.Remove(bookingSesson);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
