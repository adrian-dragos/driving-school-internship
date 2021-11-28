using Application.DTOs.EntityDtos.Car;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetCarList
{
    public class GetCarListQuery : IRequest<IEnumerable<CarDto>>
    {
        public CarDto carDto;
    }
}
