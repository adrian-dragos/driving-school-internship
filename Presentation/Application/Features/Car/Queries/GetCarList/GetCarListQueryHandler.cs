using Application.DTOs.Car;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetCarList
{
    public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, IEnumerable<CarDto>>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarListQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDto>> Handle(GetCarListQuery query, CancellationToken cancellationToken)
        {
            var car = await _repository.GetAll();
            return _mapper.Map<List<CarDto>>(car);
        }
    }
}
