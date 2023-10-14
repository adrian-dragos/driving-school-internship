using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Features.Instructors.Commands.UpdateEmploymentStatus;
using IntegrationTests.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public class InstructorsControllerTests
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
        public async Task GetInstructors_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/instructors");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetInstructors_ShouldReturnExistingInstructors()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/instructors");

            var result = await response.Content.ReadAsStringAsync();
            var instructors = JsonConvert.DeserializeObject<List<InstructorDto>>(result);

            var instructor = instructors.FirstOrDefault(b => b.Id == 1);
        }

        [TestMethod]
        public async Task GetInstructorById_ShouldReturnExistingInstructor()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/instructors/1");

            var result = await response.Content.ReadAsStringAsync();
            var instructor = JsonConvert.DeserializeObject<InstructorDto>(result);

            Assert.AreEqual("Mihai", instructor.FirstName);
            Assert.AreEqual("Ionascu", instructor.LastName);
            Assert.AreEqual("mihai.ionascu23@gmail.com", instructor.Email);
            Assert.AreEqual("+40 742 950 144", instructor.PhoneNumber);
            Assert.AreEqual(new DateTime(1982, 02, 27), instructor.Birthday);
            Assert.AreEqual(true, instructor.IsCurrentlyEmployed);
            Assert.AreEqual(4, instructor.CarId);
        }

        [TestMethod]
        public async Task PostInstructor_ShouldReturnCreatedResponse()
        {
            var newInstructor = new CreateInstructorDto()
            {
                FirstName = "Mihai",
                LastName = "Ionascu",
                Email = "mihai.ionascu23@gmail.com",
                PhoneNumber = "+40 742 950 144",
                Birthday = new DateTime(1982, 02, 27),
                IsCurrentlyEmployed = false,
                CarId = null
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/instructors",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }


        [TestMethod]
        public async Task PostInstructor_ShouldReturnCreatedInstructor()
        {
            var newInstructor = new CreateInstructorDto()
            {
                FirstName = "Mihai",
                LastName = "Ionascu",
                Email = "mihai.ionascu23@gmail.com",
                PhoneNumber = "+40 742 950 144",
                Birthday = new DateTime(1982, 02, 27),
                IsCurrentlyEmployed = false,
                CarId = null
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/instructors",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var instructor = JsonConvert.DeserializeObject<InstructorDto>(result);

            Assert.AreEqual(newInstructor.FirstName, instructor.FirstName);
            Assert.AreEqual(newInstructor.LastName, instructor.LastName);
            Assert.AreEqual(newInstructor.PhoneNumber, instructor.PhoneNumber);
            Assert.AreEqual(newInstructor.Email, instructor.Email);
            Assert.AreEqual(newInstructor.Birthday, instructor.Birthday);
            Assert.AreEqual(newInstructor.IsCurrentlyEmployed, instructor.IsCurrentlyEmployed);
            Assert.AreEqual(newInstructor.CarId, instructor.CarId);
        }

        [TestMethod]
        public async Task UpdateInstructorCar_ShouldReturnNoContentResponse()
        {
            var newInstructor = new ChangeInstructorCarDto()
            {
                CarId = 2
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/instructors/car/2",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateInstructorCar_ShouldReturnErrorResponseIfInvalidInstructorIdIsProvided()
        {
            var newInstructor = new ChangeInstructorCarDto()
            {
                CarId = 2
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/instructors/car/0",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateInstructorCar_ShouldReturnErrorResponseIfCarIdDoesNotExist()
        {
            var newInstructor = new ChangeInstructorCarDto()
            {
                CarId = 0
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/instructors/car/2",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }


        [TestMethod]
        public async Task UpdateInstructorEmploymentStatus_ShouldReturnNoContentResponse()
        {
            var newInstructor = new ChangeInstructorEmploymentStatusDto()
            {
                IsCurrentlyEmployed = true
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/instructors/employment-status/2",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateInstructorEmploymentStatus_ShouldReturnErrorResponseIfInvalidInstructorIdIsProvided()
        {
            var newInstructor = new ChangeInstructorEmploymentStatusDto()
            {
                IsCurrentlyEmployed = true
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/instructors/employment-status/0",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

    }
}
