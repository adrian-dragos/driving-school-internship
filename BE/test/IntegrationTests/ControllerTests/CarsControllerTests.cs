using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EnumDtos;
using Domain.Enums;
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
    public class CarsControllerTests
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
        public async Task GetCars_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cars");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetCars_ShouldReturnExistingCars()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cars");

            var result = await response.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<CarDto>>(result);

            var car = cars.FirstOrDefault(b => b.Id == 1);
        }

        [TestMethod]
        public async Task GetCarById_ShouldReturnExistingCar()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cars/1");

            var result = await response.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<CarDto>(result);

            Assert.AreEqual(1, car.Id);
            Assert.AreEqual(CarModelTypeDto.DaciaLogan, car.CarModelType);
            Assert.AreEqual(CarGearDto.Manual, car.CarGear);
            Assert.AreEqual(new DateTime(2015, 08, 1), car.CarFabricationTime);
            Assert.AreEqual("TM 152", car.RegistrationNumber);
            Assert.AreEqual(false, car.IsAvailable);
        }

        [TestMethod]
        public async Task PostCar_ShouldReturnCreatedResponse()
        {
            var newCar = new CreateCarDto()
            {
                CarModelType = CarModelTypeDto.DaciaLogan,
                CarGear = CarGearDto.Manual,
                CarFabricationTime = new DateTime(2015, 01, 1),
                RegistrationNumber = "TM 153",
                IsAvailable = false,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/cars",
                new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }


        [TestMethod]
        public async Task PostCar_ShouldReturnCreatedCar()
        {
            var newCar = new CreateCarDto()
            {
                CarModelType = CarModelTypeDto.DaciaLogan,
                CarGear = CarGearDto.Manual,
                CarFabricationTime = new DateTime(2015, 01, 1),
                RegistrationNumber = "TM 153",
                IsAvailable = false,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/cars",
                new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<CarDto>(result);

            Assert.AreEqual(newCar.CarGear, car.CarGear);
            Assert.AreEqual(newCar.CarModelType, car.CarModelType);
            Assert.AreEqual(newCar.RegistrationNumber, car.RegistrationNumber);
            Assert.AreEqual(newCar.CarFabricationTime, car.CarFabricationTime);
            Assert.AreEqual(newCar.IsAvailable, car.IsAvailable);
        }
    

        [TestMethod]
        public async Task UpdateCarAvaibilaty_ShouldReturnNoContentResponse()
        {
            var newCar = new ChangeCarAvailabilityDto()
            {
                IsAvailable = true
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/cars/1",
                new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateCarAvaibilaty_ShouldReturnNotFondIfInvalidCarrIdIsProvided()
        {
            var newCar = new ChangeCarAvailabilityDto()
            {
                IsAvailable = true
            };

            var client = _factory.CreateClient();
            var response = await client.PatchAsync("/api/car/0",
                new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
