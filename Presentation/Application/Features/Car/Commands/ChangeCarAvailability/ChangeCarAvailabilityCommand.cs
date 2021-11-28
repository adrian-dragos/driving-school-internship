using Application.DTOs.Car;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.ChangeCarAvailability
{
    public class ChangeCarAvailabilityCommand : IRequest<Unit>
    {
        public ChangeCarAvailabilityDto changeCarAvailabilityDto { get; set; }
    }
}
