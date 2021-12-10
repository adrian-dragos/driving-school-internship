using Application.DTOs.EntityDtos.Car;
using Application.Features.Car.Commands.ChangeCarAvailability;
using Application.Features.Car.Commands.CreateCar;
using Application.Features.Car.Queries.GetCar;
using Application.Features.Car.Queries.GetCarList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarDto>>> GetCars()
        {
            var cars = await _mediator.Send(new GetCarListQuery());
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _mediator.Send(new GetCarQuery { Id = id });
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarDto carDto)
        {
            var carId = await _mediator.Send(new CreateCarCommand { CarDto = carDto });
            return Ok(carId);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeCarAvailability(int id, [FromBody] ChangeCarAvailabilityDto carDto)
        {
            await _mediator.Send(new ChangeCarAvailabilityCommand { Id = id, ChangeCarAvailabilityDto = carDto });
            return NoContent();
        }
    }
}
