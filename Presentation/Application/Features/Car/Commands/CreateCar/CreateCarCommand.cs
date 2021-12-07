using Application.DTOs.EntityDtos.Car;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<int>
    {
        public CreateCarDto carDto;
    }
}
