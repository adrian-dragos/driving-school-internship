using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability
{
    public class ChangeBookingSessionAvailabilityCommandHandler : IRequestHandler<ChangeBookingSessionAvailabilityCommand, Unit>
    {
        private readonly IBookingSessionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeBookingSessionAvailabilityCommandHandler(IBookingSessionRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangeBookingSessionAvailabilityCommand command, CancellationToken cancellationToken)
        {
            var bookingSession = await _repository.GetByIdAsync(command.Id);
            _mapper.Map(command.ChangeBookingSessionAvailabilityDto, bookingSession);
            await _repository.Update(bookingSession);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
