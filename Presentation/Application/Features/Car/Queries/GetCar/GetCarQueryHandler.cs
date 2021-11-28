using Application.DTOs.Car;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetCar
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarDto>
    {
        private readonly ICarRepository _repostitory;
        private readonly IMapper _mapper;

        public GetCarQueryHandler(ICarRepository repostitory, IMapper mapper)
        {
            _repostitory = repostitory;
            _mapper = mapper;
        }

        public async Task<CarDto> Handle(GetCarQuery query, CancellationToken cancellationToken)
        {
            var car = await _repostitory.GetByIdAsync(query.Id);
            return _mapper.Map<CarDto>(car);
        }
    }
}
