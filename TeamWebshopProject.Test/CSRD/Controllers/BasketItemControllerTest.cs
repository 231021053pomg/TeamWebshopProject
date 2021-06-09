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

            // Act

            // Assert
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenBasketItemIsNull()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenBasketItemSubmittedIsNull()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenBasketItemSubmitIsOk()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenBasketItemExists()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
