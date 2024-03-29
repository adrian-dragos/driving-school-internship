﻿using Application.DTOs.EntityDtos.Car;
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
        public int Id { get; set; }
        public ChangeCarAvailabilityDto ChangeCarAvailabilityDto { get; set; }
    }
}
