using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
   public class OrderControllerTest
    {
        private readonly OrderController _controller;
        private readonly Mock<IOrderService> orderService = new();

        public OrderControllerTest()
        {
            _controller = new OrderController(orderService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<Order> orders = new List<Order>();
            orders.Add(new Order());
            orders.Add(new Order());

            orderService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {
            // Arrange
            List<Order> orders = new List<Order>();

            orderService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenOrderIsNull()
        {
            //Arrange
            List<Order> orders = null;

            orderService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orders);
            //Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenOrderSubmittedIsNull()
        {
            // Arrange
            Order order = null;

            orderService
                .Setup(s => s.Create(null))
                .ReturnsAsync(order);
            // Act
            var response = await _controller.Create(order);
            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenOrderSubmitIsOk()
        {
            // Arrange
            Order order = new Order { Price = 0 };
            orderService
                .Setup(s => s.Create(It.IsAny<Order>()))
                .ReturnsAsync(order);
            // Act
            var respone = await _controller.Create(order);

            // Assert
            var responeStatusCode = (IStatusCodeActionResult)respone;
            Assert.Equal(200, responeStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenOrderExists()
        {
            // Arrange
            int id = 1;
            decimal price = 0;


            Order order = new Order
            {
                Id = id,
                Price = price

            };

            orderService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(order);
            // Act
            var respone = await _controller.Get(id);
            // Assert
            Assert.NotNull(respone);
        }
    }
}
