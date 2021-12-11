using Application.DTOs.EntityDtos.BookingSession;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.Features.BookingSessions.Commands.CreateBookingSession;
using Application.Features.BookingSessions.Commands.CreateBookingSessionList;
using Application.Features.BookingSessions.Commands.DeteleBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSessionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PresentationApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class BookingSessionsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		#region EachRequestIsCalledOnceTests
		[Fact]
		public async Task GetBookingSessionListQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookingSessionListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			await controller.GetBookingSessions();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetBookingSessionListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetBookingSessionQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookingSessionQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			await controller.GetBookingSession(1); ;

			_mockMediator.Verify(x => x.Send(It.IsAny<GetBookingSessionQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateBookingSessionCommand_IsCalled()
		{
			var createStudentDto = new CreateBookingSessionDto
			{
				StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
				IsAvailable = true,
				InstructorId = 2,
				StudentId = null
			};

			var studentDto = new BookingSessionDto
			{
				Id = 1,
				StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
				IsAvailable = true,
				InstructorId = 2,
				StudentId = null
			};

			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateBookingSessionCommand>(), It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(studentDto))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			await controller.CreateBookingSession(createStudentDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateBookingSessionCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateBookingSessionsCommand_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateBookingSessionListCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			var bookingSessionsDto = new List<CreateBookingSessionDto>()
			{
				new CreateBookingSessionDto
				{
					StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
					IsAvailable = true,
					InstructorId = 1,
					StudentId = null
				},
				new CreateBookingSessionDto
				{
					StartTime = new DateTime(2021, 11, 12, 4, 30, 0),
					IsAvailable = true,
					InstructorId = 2,
					StudentId = null
				}
			};
			await controller.CreateBookingSessions(bookingSessionsDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateBookingSessionListCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task DeleteBookingSessionQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<DeteleBookingSessionCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			await controller.DeleteBookingSession(1);

			_mockMediator.Verify(x => x.Send(It.IsAny<DeteleBookingSessionCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task ChangeBookingSessionAvailability_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<ChangeBookingSessionAvailabilityCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			var bookingSessionsDto = new ChangeBookingSessionAvailabilityDto
			{
				IsAvailable = false
			};
			await controller.ChangeLessonAvailability(1, bookingSessionsDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<ChangeBookingSessionAvailabilityCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		#endregion EachRequestIsCalledOnceTests

		#region EachRequestReturnTheExpectedResponseTests
		[Fact]
		public async Task GetBookingSessions_ShouldReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookingSessionListQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(new List<BookingSessionDto>() {
					new BookingSessionDto
					{
						Id = 8,
						StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
						IsAvailable = true,
						InstructorId = 3,
						StudentId = null
					},
					new BookingSessionDto
					{
						Id = 9,
						StartTime = new DateTime(2021, 12, 12, 3, 00, 0),
						IsAvailable = true,
						InstructorId = 4,
						StudentId = null
					}
				});

			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.GetBookingSessions();

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[Fact]
		public async Task GetStudentById_ShouldReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookingSessionQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(
					new BookingSessionDto
					{
						Id = 8,
						StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
						IsAvailable = true,
						InstructorId = 3,
						StudentId = null
					});

			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.GetBookingSession(1);

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}


		[Fact]
		public async Task CreateCar_ShouldReturnCreatedStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<CreateBookingSessionCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(
						new BookingSessionDto
						{
							Id = 9,
							StartTime = new DateTime(2021, 12, 12, 3, 00, 0),
							IsAvailable = true,
							InstructorId = 4,
							StudentId = null
						});

			var bookingSession = new CreateBookingSessionDto
			{
				StartTime = new DateTime(2021, 12, 12, 3, 00, 0),
				IsAvailable = true,
				InstructorId = 4,
				StudentId = null
			};
			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.CreateBookingSession(bookingSession);

			var objectResponse = result.Result as ObjectResult;
			Assert.Equal((int)HttpStatusCode.Created, objectResponse.StatusCode);
		}

		[Fact]
		public async Task CreateBookingSessions_ShouldReturnOkStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<CreateBookingSessionListCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(new List<int> () { 1, 2});

			var bookingSessions = new List<CreateBookingSessionDto>()
			{
				new CreateBookingSessionDto
				{
					StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
					IsAvailable = true,
					InstructorId = 3,
					StudentId = null
				},
				new CreateBookingSessionDto
				{
					StartTime = new DateTime(2021, 12, 12, 1, 30, 0),
					IsAvailable = true,
					InstructorId = 2,
					StudentId = null
				},
			};
			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.CreateBookingSessions(bookingSessions);

			var okResult = result.Result as OkObjectResult;
			Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[Fact]
		public async Task ChangeBookingSessionAvailability_ShouldReturnNoContentStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<ChangeBookingSessionAvailabilityCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(Unit.Value);

			var bookingSession = new ChangeBookingSessionAvailabilityDto
			{
				IsAvailable = false,
			};
			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.ChangeLessonAvailability(1, bookingSession);

			var noContentResult = result as NoContentResult;
			Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
		}

		[Fact]
		public async Task DeelteBookingSession_ShouldReturnNoContentStatusCode()
		{
			_mockMediator
				   .Setup(m => m.Send(It.IsAny<DeteleBookingSessionCommand>(), It.IsAny<CancellationToken>()))
				   .ReturnsAsync(Unit.Value);


			var controller = new BookingSessionsController(_mockMediator.Object);
			var result = await controller.DeleteBookingSession(1);

			var noContentResult = result as NoContentResult;
			Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
		}
		#endregion EachRequestReturnTheExpectedResponseTests
	}
}
