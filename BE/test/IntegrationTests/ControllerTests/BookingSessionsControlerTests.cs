using Application.DTOs.EntityDtos.BookingSession;
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
    public class BookingSessionsControlerTests
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
        public async Task GetBookingSessions_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/bookingsessions");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetBookingSessions_ShouldReturnExistingBookingSessino()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/bookingsessions");

            var result = await response.Content.ReadAsStringAsync();
            var bookingSessions = JsonConvert.DeserializeObject<List<BookingSessionDto>>(result);

            var bookingSession = bookingSessions.FirstOrDefault(b => b.Id == 6);
        }

        //[TestMethod]
        //public async Task GetBookingSessionsById_ShouldReturnExistingBookingSession()
        //{
        //    var client = _factory.CreateClient();
        //    var response = await client.GetAsync("api/bookingsessions/7");

        //    var result = await response.Content.ReadAsStringAsync();
        //    var bookingSession = JsonConvert.DeserializeObject<BookingSessionDto>(result);

        //    Assert.AreEqual(new DateTime(2021, 12, 12, 4, 30, 0), bookingSession.StartTime);
        //    Assert.AreEqual(true, bookingSession.IsAvailable);
        //    Assert.AreEqual(1, bookingSession.InstructorId);
        //    Assert.AreEqual(null, bookingSession.StudentId);
        //}

        [TestMethod]
        public async Task PostBookingSession_ShouldReturnCreatedResponse()
        {
            var newBookingSessino = new CreateBookingSessionDto()
            {
                StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                IsAvailable = true,
                InstructorId = 1,
                StudentId = null
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/bookingsessions/booking-session",
                new StringContent(JsonConvert.SerializeObject(newBookingSessino), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task PostBookingSessions_ShouldReturnCreatedResponse()
        {
            var newBookingSessino = new List<CreateBookingSessionDto>() {
                new CreateBookingSessionDto
                {
                StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                IsAvailable = true,
                InstructorId = 2,
                StudentId = null
                },
                new CreateBookingSessionDto
                {
                StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                IsAvailable = true,
                InstructorId = 1,
                StudentId = null
                }
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/bookingsessions/booking-sessions",
                new StringContent(JsonConvert.SerializeObject(newBookingSessino), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task PostBookingSession_ShouldCreateBookingSessionDtouldReturnCreatedBookingSession()
        {
            var newBookingSession = new CreateBookingSessionDto()
            {
                StartTime = new DateTime(2021, 12, 12, 4, 30, 0),
                IsAvailable = true,
                InstructorId = 1,
                StudentId = null
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/bookingsessions/booking-session",
                new StringContent(JsonConvert.SerializeObject(newBookingSession), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var bookingSession = JsonConvert.DeserializeObject<BookingSessionDto>(result);

            Assert.AreEqual(newBookingSession.StartTime, bookingSession.StartTime);
            Assert.AreEqual(newBookingSession.IsAvailable, bookingSession.IsAvailable);
            Assert.AreEqual(newBookingSession.InstructorId, bookingSession.InstructorId);
            Assert.AreEqual(newBookingSession.StudentId, bookingSession.StudentId);
        }

        [TestMethod]
        public async Task UpdateBookingSessionAvailability_ShouldReturnNoContentResponse()
        {
            var newInstructor = new ChangeBookingSessionAvailabilityDto()
            {
                IsAvailable = true,
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/bookingsessions/7",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateBookingSessionAvailability_ShouldReturnErrorResponseIfInvalidInstructorIdIsProvided()
        {
            var newInstructor = new ChangeBookingSessionAvailabilityDto()
            {
                IsAvailable = true,
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/bookingsessions/0",
                new StringContent(JsonConvert.SerializeObject(newInstructor), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteBookingSession_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/bookingsessions/1");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
