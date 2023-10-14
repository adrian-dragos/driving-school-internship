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


        #region EachRequestIsCalledOnceTests
        [Fact]
		public async Task GetCarList_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCars();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetCarListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetCar_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCar(2);

			_mockMediator.Verify(x => x.Send(It.IsAny<GetCarQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateCar_IsCalled()
		{
			var createStudentDto = new CreateCarDto
			{
				CarModelType = CarModelTypeDto.SkodaFabia,
				CarGear = CarGearDto.Automatic,
				CarFabricationTime = new DateTime(2017, 03, 1),
				RegistrationNumber = "TM 055",
				IsAvailable = false,
			};

			var studentDto = new CarDto
			{
				Id = 1,
				CarModelType = CarModelTypeDto.SkodaFabia,
				CarGear = CarGearDto.Automatic,
				CarFabricationTime = new DateTime(2017, 03, 1),
				RegistrationNumber = "TM 055",
				IsAvailable = false,
			};

			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(studentDto))
				.Verifiable();

			var controller = new CarsController(_mockMediator.Object);
			await controller.CreateCar(createStudentDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task ChangeCarAvailability_IsCalled()
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
		#endregion EachRequestIsCalledOnceTests

		#region EachRequestReturnTheExpectedResponseTests
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
							CarFabricationTime = new DateTime(2017, 03, 1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						},
						new CarDto
						{
							Id = 2,
							CarModelType = CarModelTypeDto.DaciaSandero,
							CarGear = CarGearDto.Manual,
							CarFabricationTime = new DateTime(2017, 03, 1),
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
							CarFabricationTime = new DateTime(2017, 03, 1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						});

			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.GetCar(1);

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[Fact]
		public async Task CreateCar_ShouldReturnCreatedStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(
						new CarDto
						{
							Id = 2,
							CarModelType = CarModelTypeDto.DaciaSandero,
							CarGear = CarGearDto.Manual,
							CarFabricationTime = new DateTime(2017, 03, 1),
							RegistrationNumber = "TM 824",
							IsAvailable = false,
						});

			var car = new CreateCarDto
			{
				CarModelType = CarModelTypeDto.DaciaSandero,
				CarGear = CarGearDto.Manual,
				CarFabricationTime = new DateTime(2017, 03, 1),
				RegistrationNumber = "TM 824",
				IsAvailable = false,
			};
			var controller = new CarsController(_mockMediator.Object);
			var result = await controller.CreateCar(car);

			var objectResponse = result.Result as ObjectResult;
			Assert.Equal((int)HttpStatusCode.Created, objectResponse.StatusCode);
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
							CarFabricationTime = new DateTime(2017, 03, 1),
							RegistrationNumber = "TM 055",
							IsAvailable = false,
						});
				});

			var controller = new CarsController(_mockMediator.Object);
			await controller.GetCar(1);

			Assert.Equal(carId, 1);
		}
		#endregion EachRequestReturnTheExpectedResponseTests
	}
}
