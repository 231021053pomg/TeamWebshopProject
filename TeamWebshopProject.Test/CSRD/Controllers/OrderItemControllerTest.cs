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
    public class OrderItemControllerTest
    {
        private readonly OrderItemController _controller;
        private readonly Mock<IOrderItemService> orderItemService = new();

        public OrderItemControllerTest()
        {
            _controller = new OrderItemController(orderItemService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem());
            orderItems.Add(new OrderItem());

            orderItemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orderItems);

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
            List<OrderItem> orderItems = new List<OrderItem>();

            orderItemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orderItems);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenOrderItemIsNull()
        {
            //Arrange
            List<OrderItem> orderItems = null;

            orderItemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(orderItems);
            //Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenOrderItemSubmittedIsNull()
        {
            // Arrange
            OrderItem orderItem = null;

            orderItemService
                .Setup(s => s.Create(null))
                .ReturnsAsync(orderItem);
            // Act
            var response = await _controller.Create(orderItem);
            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenOrderItemSubmitIsOk()
        {
            // Arrange
            OrderItem orderItem = new OrderItem { Quantity = 0 };
            orderItemService
                .Setup(s => s.Create(It.IsAny<OrderItem>()))
                .ReturnsAsync(orderItem);
            // Act
            var respone = await _controller.Create(orderItem);

            // Assert
            var responeStatusCode = (IStatusCodeActionResult)respone;
            Assert.Equal(200, responeStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenOrderItemExists()
        {
            // Arrange
            int id = 1;
            int quantity = 0;


            OrderItem orderItem = new OrderItem
            {
                Id = id,
                Quantity = quantity
                
                
            };

            orderItemService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(orderItem);
            // Act
            var respone = await _controller.Get(id);
            // Assert
            Assert.NotNull(respone);
        }
    }
}
