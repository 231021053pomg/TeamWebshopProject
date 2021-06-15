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
    public class BasketControllerTest
    {
        private readonly BasketController _controller;
        private readonly Mock<IBasketService> basketService = new();

        public BasketControllerTest()
        {
            _controller = new BasketController(basketService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<Basket> baskets = new List<Basket>();

            baskets.Add(new Basket());
            baskets.Add(new Basket());

            basketService
                .Setup(s => s.GetAll())
                .ReturnsAsync(baskets);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {
            // Arrange
            List<Basket> baskets = new List<Basket>();

            basketService
                .Setup(s => s.GetAll())
                .ReturnsAsync(baskets);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenBasketIsNull()
        {
            // Arrange
            List<Basket> baskets = null;

            basketService
                .Setup(s => s.GetAll())
                .ReturnsAsync(baskets);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenBasketSubmittedIsNull()
        {
            // Arrange
            Basket basket = null;

            basketService
                .Setup(s => s.Create(null))
                .ReturnsAsync(basket);

            // Act
            var response = await _controller.Create(basket);

            // Assert
            var responseStatuscode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatuscode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenBasketSubmitIsOk()
        {
            // Arrange
            Basket basket = new Basket { Quantity = 0, Price = 0 };

            basketService
                .Setup(s => s.Create(It.IsAny<Basket>()))
                .ReturnsAsync(basket);

            // Act
            var response = await _controller.Create(basket);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenBasketExists()
        {
            // Arrange
            int id = 1;
            int quantity = 5;
            int price = 100;

            Basket basket = new Basket
            {
                Id = id,
                Quantity = quantity,
                Price = price
            };

            basketService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(basket);

            // Act
            var response = await _controller.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
