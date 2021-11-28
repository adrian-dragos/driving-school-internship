using Application.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.CreateCar
{
    public class CreateBookingSessionCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingSessionCommandHandler(ICarRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Domain.Entities.Car>(command.carDto);
            car = await _repository.AddAsync(car);
            await _unitOfWork.Save();
            return car.Id;
        }
    }
}
