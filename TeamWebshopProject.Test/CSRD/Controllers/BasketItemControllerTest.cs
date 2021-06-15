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
    public class BasketItemControllerTest
    {
        private readonly BasketItemController _controller;
        private readonly Mock<IBasketItemService> basketItemService = new();

        public BasketItemControllerTest()
        {
            _controller = new BasketItemController(basketItemService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<BasketItem> basketItems = new List<BasketItem>();
            basketItems.Add(new BasketItem());
            basketItems.Add(new BasketItem());

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
            List<BasketItem> basketItems = new List<BasketItem>();

            basketItemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(basketItems);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenBasketItemIsNull()
        {
            // Arrange
            List<BasketItem> basketItems = null;

            basketItemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(basketItems);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenBasketItemSubmittedIsNull()
        {
            // Arrange
            BasketItem basketItem = null;

            basketItemService
                .Setup(s => s.Create(null))
                .ReturnsAsync(basketItem);

            // Act
            var response = await _controller.Create(basketItem);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenBasketItemSubmitIsOk()
        {
            // Arrange
            BasketItem basketItem = new BasketItem { Quantity = 0 };

            basketItemService
                .Setup(s => s.Create(It.IsAny<BasketItem>()))
                .ReturnsAsync(basketItem);

            // Act
            var reponse = await _controller.Create(basketItem);

            // Assert
            var reponseStatusCode = (IStatusCodeActionResult)reponse;
            Assert.Equal(200, reponseStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenBasketItemExists()
        {
            // Arrange
            int id = 1;
            int quantity = 50;

            BasketItem basketItem = new BasketItem
            {
                Id = id,
                Quantity = quantity
            };

            basketItemService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(basketItem);

            // Act
            var response = await _controller.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
