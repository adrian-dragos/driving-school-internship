using Application.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.EntityDtos.Car;

namespace Application.Features.Car.Commands.CreateCar
{
    public class CreateBookingSessionCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
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

        public async Task<CarDto> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Domain.Entities.Car>(command.CarDto);
            car = await _repository.AddAsync(car);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CarDto>(car);
        }
    }
}
