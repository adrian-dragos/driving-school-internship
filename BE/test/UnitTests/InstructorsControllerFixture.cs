using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Features.Instructors.Commands.CreateInstructor;
using Application.Features.Instructors.Commands.UpdateEmploymentStatus;
using Application.Features.Instructors.Quieries.GetInstructor;
using Application.Features.Instructors.Quieries.GetInstructorsList;
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
    public class InstructorsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		#region EachRequestIsCalledOnceTests
		[Fact]
		public async Task GetInstructorList_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetInstructorListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			await controller.GetInstructors();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetInstructorListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetInstructor_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetInstructorQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			await controller.GetInstructor(1); 

			_mockMediator.Verify(x => x.Send(It.IsAny<GetInstructorQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

        [Fact]
        public async Task CreateInstructor_IsCalled()
        {
            var createInstructorDto = new CreateInstructorDto
            {
                FirstName = "Mihai",
                LastName = "Ionascu",
                Email = "mihai.ionascu23@gmail.com",
                PhoneNumber = "+40 742 950 144",
                Birthday = new DateTime(1982, 02, 27),
                IsCurrentlyEmployed = true,
                CarId = 4
            };

            var instructorDto = new InstructorDto
            {
                Id = 1,
                FirstName = "Mihai",
                LastName = "Ionascu",
                Email = "mihai.ionascu23@gmail.com",
                PhoneNumber = "+40 742 950 144",
                Birthday = new DateTime(1982, 02, 27),
                IsCurrentlyEmployed = true,
                CarId = 4
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<CreateInstructorCommand>(), It.IsAny<CancellationToken>()))
             .Returns(Task.FromResult(instructorDto))
             .Verifiable();


            var controller = new InstructorsController(_mockMediator.Object);
            await controller.CreateInstructor(createInstructorDto);

            _mockMediator.Verify(x => x.Send(It.IsAny<CreateInstructorCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
		public async Task UpdateInstructorCar_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new InstructorsController(_mockMediator.Object);
			var instructorDto = new ChangeInstructorCarDto()
            {
				CarId = 2
			};
			await controller.UpdateInstructorCar(1, instructorDto);

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
        #endregion EachRequestIsCalledOnceTests

        #region EachRequestReturnTheExpectedResponseTests
        [Fact]
        public async Task GetInstructors_ShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetInstructorListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<InstructorDto>() {
                        new InstructorDto
                        {
                            Id = 3,
                            FirstName = "Radu",
                            LastName = "Mazur",
                            Email = "radu.mazur88@gmail.com",
                            PhoneNumber = "+40 722 101 021",
                            Birthday = new DateTime(1988, 08, 17),
                            IsCurrentlyEmployed = true,
                            CarId = 5,
                        },
                        new InstructorDto
                        {
                            Id = 4,
                            FirstName = "Dionis",
                            LastName = "Agapii",
                            Email = "dionis.agapii@gmail.com",
                            PhoneNumber = "+40 751 551 100",
                            Birthday = new DateTime(1978, 11, 01),
                            IsCurrentlyEmployed = true,
                            CarId = 1
                        }
                    });

            var controller = new InstructorsController(_mockMediator.Object);
            var result = await controller.GetInstructors();

            var okResult = result.Result as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetInstructorsById_ShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetInstructorQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                        new InstructorDto
                        {
                            Id = 4,
                            FirstName = "Dionis",
                            LastName = "Agapii",
                            Email = "dionis.agapii@gmail.com",
                            PhoneNumber = "+40 751 551 100",
                            Birthday = new DateTime(1978, 11, 01),
                            IsCurrentlyEmployed = true,
                            CarId = 1
                        });

            var controller = new InstructorsController(_mockMediator.Object);
            var result = await controller.GetInstructor(1);

            var okResult = result.Result as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task CreateInstructor_ShouldReturnCreatedStatusCode()
        {
            _mockMediator
                   .Setup(m => m.Send(It.IsAny<CreateInstructorCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(new InstructorDto());

            var instructor = new CreateInstructorDto
            {
                FirstName = "Dionis",
                LastName = "Agapii",
                Email = "dionis.agapii@gmail.com",
                PhoneNumber = "+40 751 551 100",
                Birthday = new DateTime(1978, 11, 01),
                IsCurrentlyEmployed = true,
                CarId = 1
            };
            var controller = new InstructorsController(_mockMediator.Object);
            var result = await controller.CreateInstructor(instructor);

            var okResult = result.Result as ObjectResult;
            Assert.Equal((int)HttpStatusCode.Created, okResult.StatusCode);
        }

        [Fact]
        public async Task ChangeInstructorEmploymentStatus_ShouldReturnNoContentStatusCode()
        {
            _mockMediator
                   .Setup(m => m.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(Unit.Value);

            var instructor = new ChangeInstructorEmploymentStatusDto
            {
                IsCurrentlyEmployed = true
            };
            var controller = new InstructorsController(_mockMediator.Object);
            var result = await controller.UpdateEmploymentStatus(1, instructor);

            var noContentResult = result as NoContentResult;
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task ChangeInstructorCar_ShouldReturnNoContentStatusCode()
        {
            _mockMediator
                   .Setup(m => m.Send(It.IsAny<UpdateInstructorCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(Unit.Value);

            var instructor = new ChangeInstructorCarDto
            {
                CarId = 1
            };
            var controller = new InstructorsController(_mockMediator.Object);
            var result = await controller.UpdateInstructorCar(1, instructor);

            var noContentResult = result as NoContentResult;
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
        #endregion EachRequestReturnTheExpectedResponseTests
    }
}
