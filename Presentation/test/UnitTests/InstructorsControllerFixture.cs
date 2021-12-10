using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Features.Instructors.Commands.CreateInstructor;
using Application.Features.Instructors.Commands.UpdateEmploymentStatus;
using Application.Features.Instructors.Quieries.GetInstructor;
using Application.Features.Instructors.Quieries.GetInstructorsList;
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
    public class InstructorsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		#region EachRequestIsCalledOnce
		[Fact]
		public async Task GetInstructorListQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetInstructorListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			await controller.GetInstructors();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetInstructorListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetInstructorQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetInstructorQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			await controller.GetInstructor(1); 

			_mockMediator.Verify(x => x.Send(It.IsAny<GetInstructorQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateInstructorCommand_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateInstructorCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			var instructorDto = new CreateInstructorDto
			{
				FirstName = "Radu",
				LastName = "Mazur",
				Email = "radu.mazur88@gmail.com",
				PhoneNumber = "+40 722 101 021",
				Birthday = new DateTime(1988, 08, 17),
				IsCurrentlyEmployed = true,
				CarId = 5,
			};
			await controller.CreateInstructor(instructorDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateInstructorCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task UpdateCar_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			var instructorDto = new ChangeInstructorCarDto()
            {
				CarId = 2
			};
			await controller.UpdateCar(1, instructorDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task UpdateEmploymentStatus_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			var instructorDto = new ChangeInstructorEmploymentStatusDto()
			{
				IsCurrentlyEmployed = true
			};
			await controller.UpdateEmploymentStatus(1, instructorDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		#endregion EachRequestIsCalledOnce
	}
}
