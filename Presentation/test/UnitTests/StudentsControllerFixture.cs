using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.Students.Commands.CreateStudent;
using Application.Features.Students.Queries.GetStudent;
using Application.Features.Students.Queries.GetStudentsList;
using Domain.Entities.Person;
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
    public class StudentsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        #region EachRequestIsCalledOnceTests
        [Fact]
        public async Task GetStudentList_IsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new StudentsController(_mockMediator.Object);
            await controller.GetStudents();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetStudentListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GetStudent_IsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            
            var controller = new StudentsController(_mockMediator.Object);
            await controller.GetStudent(2); ;

            _mockMediator.Verify(x => x.Send(It.IsAny<GetStudentQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task CreateStudent_IsCalled()
        {
            var createStudentDto = new CreateStudentDto
            {
                FirstName = "Petru",
                LastName = "Lucu",
                Email = "petru.lucu@gmail.com",
                PhoneNumber = "+40 060 066 144",
                Birthday = new DateTime(1945, 01, 21)
            };

            var studentDto = new StudentDto
            {
                Id = 1,
                FirstName = "Petru",
                LastName = "Lucu",
                Email = "petru.lucu@gmail.com",
                PhoneNumber = "+40 060 066 144",
                Birthday = new DateTime(1945, 01, 21)
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(studentDto))
                .Verifiable();

            var controller = new StudentsController(_mockMediator.Object);
            await controller.CreateStudent(createStudentDto);
            
            _mockMediator.Verify(x => x.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        #endregion EachRequestIsCalledOnceTests

        #region EachRequestReturnTheExpectedResponseTests
        [Fact]
        public async Task GetStudents_ShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<StudentDto>() {
                        new StudentDto
                        {
                            Id = 9,
                           FirstName = "Alexandru",
                           LastName = "Lungu",
                           Email = "alexandru.lungu2002@gmail.com",
                           PhoneNumber = "+40 513 153 531",
                           Birthday = new DateTime(2002, 03, 07)
                        },
                        new StudentDto
                        {
                            Id = 10,
                            FirstName = "Paul",
                            LastName = "Rus",
                            Email = "paul.rus2003@gmail.com",
                            PhoneNumber = "+40 474 366 386",
                            Birthday = new DateTime(2003, 08, 01)
                        }
                    });

            var controller = new StudentsController(_mockMediator.Object);
            var result = await controller.GetStudents();

            var okResult = result.Result as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetStudentById_ShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                        new StudentDto
                        {
                            Id = 9,
                            FirstName = "Alexandru",
                            LastName = "Lungu",
                            Email = "alexandru.lungu2002@gmail.com",
                            PhoneNumber = "+40 513 153 531",
                            Birthday = new DateTime(2002, 03, 07)
                        });

            var controller = new StudentsController(_mockMediator.Object);
            var result = await controller.GetStudent(1);

            var okResult = result.Result as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnCreatedStatusCode()
        {
            _mockMediator
                   .Setup(m => m.Send(It.IsAny<CreateStudentCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(
                        new StudentDto
                           {
                               Id = 9,
                               FirstName = "Alexandru",
                               LastName = "Lungu",
                               Email = "alexandru.lungu2002@gmail.com",
                               PhoneNumber = "+40 513 153 531",
                               Birthday = new DateTime(2002, 03, 07)
                           });

            var student = new CreateStudentDto
            {
                FirstName = "Alexandru",
                LastName = "Lungu",
                Email = "alexandru.lungu2002@gmail.com",
                PhoneNumber = "+40 513 153 531",
                Birthday = new DateTime(2002, 03, 07)
            };
            var controller = new StudentsController(_mockMediator.Object);
            var result = await controller.CreateStudent(student);

            var objectResponse = result.Result as ObjectResult;
            Assert.Equal((int)HttpStatusCode.Created, objectResponse.StatusCode);
        }
        #endregion EachRequestReturnTheExpectedResponseTests
    }
}
