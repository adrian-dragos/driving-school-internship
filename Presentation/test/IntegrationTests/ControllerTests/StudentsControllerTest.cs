using Application.DTOs.EntityDtos.Person.Student;
using Application.Features.Students.Commands.CreateStudent;
using IntegrationTests.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PresentationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.ControllerTests
{
    [TestClass]
    public class StudentsControllerTest
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;


        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task GetStudents_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/students");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetStudents_ShouldReturnExistingStudent()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/students");

            var result = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<List<StudentDto>>(result);

            var student = students.FirstOrDefault(b => b.Id == 6);
        }

        [TestMethod]
        public async Task GetStudentsById_ShouldReturnExistingStudent()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/students/7");

            var result = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<StudentDto>(result);

            Assert.AreEqual("Marin", student.FirstName);
            Assert.AreEqual("Grosu", student.LastName);
            Assert.AreEqual("grosu.marin41@gmail.com", student.Email);
            Assert.AreEqual("+40 614 411 421", student.PhoneNumber);
            Assert.AreEqual(new DateTime(2003, 04, 18), student.Birthday);
        }

        [TestMethod]
        public async Task PostStudent_ShouldReturnCreatedResponse()
        {
            var newStudent = new CreateStudentDto()
            {
                FirstName = "Ion",
                LastName = "Petru",
                Email = "ion.petru@gmail.com",
                PhoneNumber = "+40 040 061 142",
                Birthday = new DateTime(1930, 11, 12)
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/students",
                new StringContent(JsonConvert.SerializeObject(newStudent), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }


        [TestMethod]
        public async Task PostStudent_ShouldReturnCreatedStudent()
        {
            var newStudent = new CreateStudentDto()
            {
                FirstName = "Ion",
                LastName = "Petru",
                Email = "ion.petru@gmail.com",
                PhoneNumber = "+40 040 061 142",
                Birthday = new DateTime(1930, 11, 12)
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/students",
                new StringContent(JsonConvert.SerializeObject(newStudent), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<StudentDto>(result);

            Assert.AreEqual(newStudent.FirstName, student.FirstName);
            Assert.AreEqual(newStudent.LastName, student.LastName);
            Assert.AreEqual(newStudent.PhoneNumber, student.PhoneNumber);
            Assert.AreEqual(newStudent.Email, student.Email);
            Assert.AreEqual(newStudent.Birthday, student.Birthday);
        }
    }
}
