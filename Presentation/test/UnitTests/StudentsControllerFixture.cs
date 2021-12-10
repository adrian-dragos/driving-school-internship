using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.Students.Commands.CreateStudent;
using Application.Features.Students.Queries.GetStudent;
using Application.Features.Students.Queries.GetStudentsList;
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
    public class StudentsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		#region EachRequestIsCalledOnce
		[Fact]
		public async Task GetStudentListQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetStudentListQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new StudentsController(_mockMediator.Object);
			await controller.GetStudents();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetStudentListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task GetStudentQuery_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetStudentQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new StudentsController(_mockMediator.Object);
			await controller.GetStudent(2); ;

			_mockMediator.Verify(x => x.Send(It.IsAny<GetStudentQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact]
		public async Task CreateStudentCommand_IsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			var controller = new StudentsController(_mockMediator.Object);
			var studentDto = new CreateStudentDto
			{
				FirstName = "Petru",
				LastName = "Lucu",
				Email = "petru.lucu@gmail.com",
				PhoneNumber = "+40 060 066 144",
				Birthday = new DateTime(1945, 01, 21)
			};
			await controller.CreateStudent(studentDto);

			_mockMediator.Verify(x => x.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		#endregion EachRequestIsCalledOnce
	}
}
