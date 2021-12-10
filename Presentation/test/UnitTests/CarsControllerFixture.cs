using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EnumDtos;
using Application.Features.Car.Commands.ChangeCarAvailability;
using Application.Features.Car.Commands.CreateCar;
using Application.Features.Car.Queries.GetCar;
using Application.Features.Car.Queries.GetCarList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PresentationApi.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class CarsControllerFixture
    {
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();


        #region EachRequestIsCalledOnce
        [Fact]
		public async Task GetCarListQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCars();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetCarListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetCarQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCar(2);

			_mockMediator.Verify(x => x.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateCarCommand_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			var carDto = new CreateCarDto
			{
				CarModelType = CarModelTypeDto.SkodaFabia,
				CarGear = CarGearDto.Automatic,
				CarFabricationTime = new DateTime(
						Convert.ToInt32(2017),
						Convert.ToInt32(03),
						1),
				RegistrationNumber = "TM 055",
				IsAvailable = false,
			};
			await controller.CreateCar(carDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task ChangeCarAvailabilityCommand_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<ChangeCarAvailabilityCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			var carDto = new ChangeCarAvailabilityDto
			{
				IsAvailable = true,
			};
			await controller.ChangeCarAvailability(1, carDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<ChangeCarAvailabilityCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		#endregion EachRequestIsCalledOnce

		#region EachRequestReturnTheExpectedResponse
		[Fact]
		public async Task GetCars_ShouldReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarListQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(new List<CarDto>() {
						new CarDto
						{
							Id = 2,
							CarModelType = CarModelTypeDto.DaciaSandero,
							CarGear = CarGearDto.Manual,
							CarFabricationTime = new DateTime(
								Convert.ToInt32(2017),
								Convert.ToInt32(02),
								1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						},
						new CarDto
						{
							Id = 2,
							CarModelType = CarModelTypeDto.DaciaSandero,
							CarGear = CarGearDto.Manual,
							CarFabricationTime = new DateTime(
								Convert.ToInt32(2017),
								Convert.ToInt32(02),
								1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						}
					});

			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.GetCars();

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[Fact]
		public async Task GetCarById_ShouldReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(
						new CarDto
						{
							Id = 2,
							CarModelType = CarModelTypeDto.DaciaSandero,
							CarGear = CarGearDto.Manual,
							CarFabricationTime = new DateTime(
								Convert.ToInt32(2017),
								Convert.ToInt32(02),
								1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						});

			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.GetCar(1);

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}


		[Fact]
		public async Task CreateCar_ShouldReturnOkStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(1);

			var car = new CreateCarDto
			{
				CarModelType = CarModelTypeDto.DaciaSandero,
				CarGear = CarGearDto.Manual,
				CarFabricationTime = new DateTime(
								Convert.ToInt32(2017),
								Convert.ToInt32(02),
								1),
				RegistrationNumber = "TM 824",
				IsAvailable = false,
			};
			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.CreateCar(car);

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[Fact]
		public async Task ChangeCarAvailability_ShouldReturnNoContentStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<ChangeCarAvailabilityCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(Unit.Value);

			var car = new ChangeCarAvailabilityDto
			{
				IsAvailable = false,
			};
			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.ChangeCarAvailability(1, car);

			var noContentResult = result as NoContentResult;
			Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
		}
		#endregion EachRequestReturnTheExpectedResponse

		[Fact]
		public async Task GetCarById_GetCarQueryWithCorrectCarIdIsCalled()
		{
			int carId = 0;

			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()))
				.Returns<GetCarQuery, CancellationToken>(async (q, c) =>
				{
					carId = q.Id;
					return await Task.FromResult(
						new CarDto
						{
							Id = q.Id,
							CarModelType = CarModelTypeDto.SkodaFabia,
							CarGear = CarGearDto.Automatic,
							CarFabricationTime = new DateTime(
								Convert.ToInt32(2017),
								Convert.ToInt32(03),
								1),
							RegistrationNumber = "TM 055",
							IsAvailable = false,
						});
				});

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCar(1);

			Assert.Equal(carId, 1);
		}
	}
}
