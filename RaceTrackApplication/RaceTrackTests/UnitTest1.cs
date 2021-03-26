using Moq;
using RaceTrackApplication.Controllers;
using RaceTrackApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace RaceTrackTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void GetVehiclesData_ReturnsAJsonResult_WithAListOfVehicles()
        {
            // Arrange
            var mockRepo = new Mock<RaceTrackApplication.Data.IRepository>();
            mockRepo.Setup(repo => repo.GetVehicles())
                .Returns(GetTestVehicles());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.GetVehiclesData();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Vehicle>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Vehicle> GetTestVehicles()
        {
            return new List<Vehicle>()
    {
        new Car()
        {
             TypeOfVehicle = "Car",
              Make="Toyota",
              Model="Camry",
               Color=Color.Black,
                Price=100,
                 Speed=50,
                  TowStrap=true,
                   MaxAccelerate=100
        },
        new Truck()
        {
             TypeOfVehicle = "Truck",
              Make="Fiat",
              Model="Dodge",
               Color=Color.White,
                Price=200,
                 Speed=70,
                  TowStrap=true,
                   MaxAccelerate=100
        }
    };
        }
    }
}
