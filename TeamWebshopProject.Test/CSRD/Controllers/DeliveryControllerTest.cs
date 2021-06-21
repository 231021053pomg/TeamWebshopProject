using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class DeliveryControllerTest
    {
        private readonly DeliveryController _deliveryController;
        private readonly Mock<IDeliveryService> deliveryService = new();

        public DeliveryControllerTest()
        {
            _deliveryController = new DeliveryController(deliveryService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn200_WhenDataExists()
        {
            // Arrange
            List<Delivery> deliveries = new List<Delivery>();
            deliveries.Add(new Delivery());
            deliveries.Add(new Delivery());

            deliveryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(deliveries);

            // Act
            var result = await _deliveryController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShoudReturn204_WhenNoDataExists()
        {
            // Arrange
            List<Delivery> customers = new List<Delivery>();

            deliveryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(customers);

            // Act
            var result = await _deliveryController.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturn500_WhenDeliveryIsNull()
        {
            // Arrrange
            List<Delivery> deliveries = null;

            deliveryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(deliveries);

            // Act
            var result = await _deliveryController.GetAll();

            // Assert 
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnStatus400_WhenDeliverySubmittedIsNull()
        {
            // Arrange
            Delivery delivery = null;

            deliveryService
                .Setup(s => s.Create(null))
                .ReturnsAsync(delivery);

            // Act
            var response = await _deliveryController.Create(delivery);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturn200_WhenDeliveryIsOk()
        {
            // Act
            Delivery delivery = new Delivery { Status = "Sent" };

            deliveryService
                .Setup(s => s.Create(It.IsAny<Delivery>()))
                .ReturnsAsync(delivery);

            // Arrange
            var response = await _deliveryController.Create(delivery);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnDelivery_WhenDeliveryExists()
        {
            // Arrange
            int id = 1;
            string status = "sent";

            Delivery delivery = new Delivery
            {
                Id = id,
                Status = status
            };

            deliveryService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(delivery);

            // Act
            var response = await _deliveryController.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
