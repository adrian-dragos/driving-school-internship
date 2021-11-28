using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetCar
{
    public class GetCarQuery : IRequest<CarDto>
    {
        public int Id { get; set; }
    }
}
