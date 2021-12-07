using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.ChangeCarAvailability
{
    public class ChangeCarAvailabilityCommandHandler : IRequestHandler<ChangeCarAvailabilityCommand, Unit>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeCarAvailabilityCommandHandler(ICarRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangeCarAvailabilityCommand command, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            _mapper.Map(command.ChangeCarAvailabilityDto, car);
            await _repository.Update(car);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
