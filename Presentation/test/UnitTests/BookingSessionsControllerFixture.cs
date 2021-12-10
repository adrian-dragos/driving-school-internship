using Application.DTOs.EntityDtos.BookingSession;
using Application.Features.BookingSessions.Commands.ChangeBookingSessionAvailability;
using Application.Features.BookingSessions.Commands.CreateBookingSession;
using Application.Features.BookingSessions.Commands.CreateBookingSessionList;
using Application.Features.BookingSessions.Commands.DeteleBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSession;
using Application.Features.BookingSessions.Queries.GetBookingSessionList;
using MediatR;
using Moq;
using PresentationApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class BookingSessionsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		#region EachRequestIsCalledOnce
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
			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateBookingSessionCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new BookingSessionsController(_mockMediator.Object);
			var bookingSessionDto = new CreateBookingSessionDto
			{
				StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
				IsAvailable = true,
				InstructorId = 1,
				StudentId = null,
			};
			await controller.CreateBookingSession(bookingSessionDto);

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
		#endregion EachRequestIsCalledOnce
	}
}
